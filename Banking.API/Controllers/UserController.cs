using Banking.Application.Users.Commands.CreateUser;
using Banking.Application.Users.Commands.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Banking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var user = await mediator.Send(new GetUserByIdQuery(id));
            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            int id = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }
    }
}
