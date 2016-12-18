using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CqrsBoilerplate.Entities.Contexts;
using CqrsBoilerplate.Entities.Users;
using CqrsBoilerplate.Models;
using CqrsBoilerplate.Models.Dto;
using CqrsBoilerplate.Models.Filters;
using CqrsBoilerplate.Models.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CqrsBoilerplate.Handlers
{
    public class UsersHandler : IAsyncRequestHandler<UsersQuery, PagedList<UserDto>>
    {
        private readonly UsersContext _usersContext;

        public UsersHandler(UsersContext usersContext)
        {
            _usersContext = usersContext;
        }

        private IQueryable<User> BuildQuery(UsersFilter filter)
        {
            var query = _usersContext.Users
                .Where(x => true);
                
            if (filter.Scope.HasFlag(UserDataScope.Membership))
            {
                query = query.Include(x => x.Membership);
            }

            if (filter.Scope.HasFlag(UserDataScope.UserInfo))
            {
                query = query.Include(x => x.UserInfo);
            }

            if (filter.PublicId.HasValue)
            {
                query = query.Where(c => c.PublicId == filter.PublicId.Value);
            }

            if (!String.IsNullOrEmpty(filter.Email))
            {
                query = query.Where(c => c.Email.ToLower().Contains(filter.Email.ToLower()));
            }

            if (!String.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(c => c.UserInfo.FirstName.ToLower().Contains(filter.Name.ToLower())
                                         || c.UserInfo.LastName.ToLower().Contains(filter.Name.ToLower()));
            }

            // sorting
            if (!String.IsNullOrEmpty(filter.SortDir) && !String.IsNullOrEmpty(filter.SortedBy))
            {
                switch (filter.SortedBy)
                {
                    case UsersFilter.UserSorting.Id:
                        query = filter.SortDir == AppConstants.SortOrder.Desc
                            ? query.OrderByDescending(r => r.Id)
                            : query.OrderBy(r => r.Id);
                        break;
                    case UsersFilter.UserSorting.Email:
                        query = filter.SortDir == AppConstants.SortOrder.Desc
                            ? query.OrderByDescending(r => r.Email)
                            : query.OrderBy(r => r.Email);
                        break;
                    case UsersFilter.UserSorting.FirstName:
                        query = filter.SortDir == AppConstants.SortOrder.Desc
                            ? query.OrderByDescending(r => r.UserInfo.FirstName)
                            : query.OrderBy(r => r.UserInfo.FirstName);
                        break;
                    case UsersFilter.UserSorting.LastName:
                        query = filter.SortDir == AppConstants.SortOrder.Desc
                            ? query.OrderByDescending(r => r.UserInfo.LastName)
                            : query.OrderBy(r => r.UserInfo.LastName);
                        break;
                    default:
                        query = query.OrderByDescending(r => r.Id);
                        break;
                }
            }
            else
            {
                query = query.OrderByDescending(r => r.Id);
            }
            return query;
        }

        public async Task<PagedList<UserDto>> GetUsers(UsersFilter filter = null)
        {
            filter = filter ?? new UsersFilter { CurrentPage = 1, PageSize = null };

            var dbQuery = BuildQuery(filter);

            var output = new PagedList<UserDto>
            {
                PageItemCount = filter.PageSize,
                CurrentPage = filter.CurrentPage
            };

            if (filter.TotalItemCountRequired)
            {
                output.TotalItemsCount = dbQuery.Count();

                if (output.TotalItemsCount == 0)
                {
                    output.Items = new UserDto[] { };
                    return output;
                };
            }

            dbQuery = dbQuery.ApplyPageFilter(filter);
            var items = await dbQuery.ToListAsync();
            output.Items = items.Select(x => ToModel(x, filter.Scope)).ToArray();

            return output;
        }

        private UserDto ToModel(User user, UserDataScope scope)
        {
            var userDto = Mapper.Map<UserDto>(user);

            if (scope.HasFlag(UserDataScope.UserInfo))
            {
                userDto.UserInfo = Mapper.Map<UserInfoDto>(user.UserInfo);
            }

            return userDto;
        }

        public Task<PagedList<UserDto>> Handle(UsersQuery message)
        {
            var filter = message.Filter;
            return GetUsers(filter);
        }
    }
}
