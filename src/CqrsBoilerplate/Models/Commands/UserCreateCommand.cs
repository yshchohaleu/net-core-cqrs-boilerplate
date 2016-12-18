using CqrsBoilerplate.Models.Dto;
using MediatR;

namespace CqrsBoilerplate.Models.Commands
{
    public class UserCreateCommand : ICancellableAsyncRequest<UserDto>
    {
        public UserCreateDto Model { get; set; }

        public UserCreateCommand(UserCreateDto model)
        {
            Model = model;
        }
    }
}
