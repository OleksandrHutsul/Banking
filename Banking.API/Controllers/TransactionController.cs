using Banking.Application.Accounts.Commands.CreateAccount;
using Banking.Application.Transactions.Commands.CreateDepositTransaction;
using Banking.Application.Transactions.Commands.CreateTransferTransaction;
using Banking.Application.Transactions.Commands.CreateWithdrawTransaction;
using Banking.Application.Transactions.Commands.Queries.GetAllTransaction;
using Banking.Application.Transactions.Commands.Queries.GetTransactionById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Banking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var transactions = await mediator.Send(new GetAllTransactionQuery());
            return Ok(transactions);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var transaction = await mediator.Send(new GetTransactionByIdQuery(id));
            if (transaction is null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

        [HttpPost("Withdraw")]
        public async Task<IActionResult> WithdrawTransaction(CreateWithdrawTransactionCommand command)
        {
            int id = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPost("Deposit")]
        public async Task<IActionResult> DepositTransaction(CreateDepositTransactionCommand command)
        {
            int id = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPost("Transfer")]
        public async Task<IActionResult> TransferTransaction(CreateTransferTransactionCommand command)
        {
            int id = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }
    }
}
