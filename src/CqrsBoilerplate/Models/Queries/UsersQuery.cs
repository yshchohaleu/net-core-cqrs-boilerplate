using CqrsBoilerplate.Models.Dto;
using CqrsBoilerplate.Models.Filters;
using MediatR;

namespace CqrsBoilerplate.Models.Queries
{
    public class UsersQuery : IAsyncRequest<PagedList<UserDto>>
    {
        public UsersQuery()
        {
            Filter = new UsersFilter();
        }

        public UsersQuery(UsersFilter filter)
            : this()
        {
            Filter = filter;
        }

        public UsersFilter Filter { get; set; }
    }
}
