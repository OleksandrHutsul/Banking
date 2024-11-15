using Banking.Application.Accounts.Commands.CreateAccount;
using Banking.Application.Accounts.Commands.DeleteAccount;
using Banking.Application.Accounts.Commands.Queries.GetAllAccounts;
using Banking.Application.Accounts.Commands.Queries.GetByIdAccount;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Banking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var restraurants = await mediator.Send(new GetAllAccountsQuery());
        return Ok(restraurants);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var restaurant = await mediator.Send(new GetByIdAccountQuery(id));
        if (restaurant is null)
        {
            return NotFound();
        }

        return Ok(restaurant);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
    {
        var isDeleted = await mediator.Send(new DeleteAccountCommand(id));

        if (isDeleted)
        {
            return NoContent();
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateRestaurant(CreateAccountCommand command)
    {
        int id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }
}
}
