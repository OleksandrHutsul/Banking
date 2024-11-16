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
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var accounts = await mediator.Send(new GetAllAccountsQuery());
            return Ok(accounts);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var account = await mediator.Send(new GetByIdAccountQuery(id));
            if (account is null)
            {
                return NotFound();
            }

            return Ok(account);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteAccount([FromRoute] int id)
        {
            var isDeleted = await mediator.Send(new DeleteAccountCommand(id));

            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAccount(CreateAccountCommand command)
        {
            int id = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }
    }
}