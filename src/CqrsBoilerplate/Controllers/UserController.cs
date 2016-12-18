using System;
using System.Threading.Tasks;
using CqrsBoilerplate.Models.Dto;
using CqrsBoilerplate.Models.Filters;
using CqrsBoilerplate.Models.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
using CqrsBoilerplate.Models.Commands;

namespace CqrsBoilerplate.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<UserDto> Get(Guid id)
        {
            var message = new UsersQuery(new UsersFilter
            {
                PublicId = id
            });
            var user = (await _mediator.SendAsync(message)).Items.SingleOrDefault();
            return user;
        }

        [HttpPost]
        public async Task<UserDto> Post([FromBody] UserCreateDto user, CancellationToken requestAborted)
        {
            var message = new UserCreateCommand(user);
            var userDto = await _mediator.SendAsync(message, requestAborted);

            return userDto;
        }
    }
}
