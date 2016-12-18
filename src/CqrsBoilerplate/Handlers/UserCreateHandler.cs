using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CqrsBoilerplate.Models.Commands;
using CqrsBoilerplate.Models.Dto;
using MediatR;
using CqrsBoilerplate.Entities.Contexts;
using CqrsBoilerplate.Entities.Users;

namespace CqrsBoilerplate.Handlers
{
    public class UserCreateHandler : ICancellableAsyncRequestHandler<UserCreateCommand, UserDto>
    {
        private readonly UsersContext _usersContext;

        public UserCreateHandler(UsersContext usersContext)
        {
            _usersContext = usersContext;
        }

        public async Task<UserDto> Handle(UserCreateCommand message, CancellationToken cancellationToken)
        {
            var user = Mapper.Map<User>(message.Model);
            user.PublicId = Guid.NewGuid();

            await _usersContext.AddAsync(user, cancellationToken);
            await _usersContext.SaveChangesAsync(cancellationToken);

            var userDto = Mapper.Map<UserDto>(user);
            return userDto;
        }
    }
}
