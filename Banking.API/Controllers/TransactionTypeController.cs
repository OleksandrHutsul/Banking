
using Banking.Application.TransactionsType.Commands.CreateTransactionType;
using Banking.Application.TransactionsType.Commands.DeleteTransactionType;
using Banking.Application.TransactionsType.Commands.Queries.GetAllTransactionType;
using Banking.Application.TransactionsType.Commands.Queries.GetTransactionTypeById;
using Banking.Application.TransactionsType.Commands.UpdateTransactionType;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Banking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionTypeController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var transactionType = await mediator.Send(new GetAllTransactionTypeQuery());
            return Ok(transactionType);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var transactionType = await mediator.Send(new GetTransactionTypeByIdQuery(id));
            if (transactionType is null)
            {
                return NotFound();
            }

            return Ok(transactionType);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteTransactionType([FromRoute] int id)
        {
            var isDeleted = await mediator.Send(new DeleteTransactionTypeCommand(id));

            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateTransactionType(CreateTransactionTypeCommand command)
        {
            int id = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateTransactionType([FromRoute] int id, [FromBody] UpdateTransactionTypeCommand command)
        {
            command.Id = id;

            try
            {
                int updatedId = await mediator.Send(command);
                return Ok(new { Message = "TransactionType updated successfully.", Id = updatedId });
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"TransactionType with ID {id} not found.");
            }
        }

    }
}
