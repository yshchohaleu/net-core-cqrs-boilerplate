using System.Threading.Tasks;
using CqrsBoilerplate.Models;
using CqrsBoilerplate.Models.Dto;
using CqrsBoilerplate.Models.Filters;
using CqrsBoilerplate.Models.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsBoilerplate.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;
        
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<PagedList<UserDto>> Get(UsersFilter filter)
        {
            var message = new UsersQuery(filter);
            var users = await _mediator.SendAsync(message);

            return users;
        }
    }
}
