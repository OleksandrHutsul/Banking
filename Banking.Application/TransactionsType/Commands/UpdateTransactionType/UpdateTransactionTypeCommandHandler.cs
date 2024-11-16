using AutoMapper;
using Banking.Domain.Entities;
using Banking.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Banking.Application.TransactionsType.Commands.UpdateTransactionType;

public class UpdateTransactionTypeCommandHandler(ILogger<UpdateTransactionTypeCommandHandler> logger,
    IMapper mapper,
    ITransactionTypeRepository transactionTypeRepository) : IRequestHandler<UpdateTransactionTypeCommand, int>
{
    public async Task<int> Handle(UpdateTransactionTypeCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Attempting to update TransactionType with ID {Id}", request.Id);

        var transactionTypeToUpdate = mapper.Map<TransactionType>(request);

        try
        {
            int id = await transactionTypeRepository.Update(transactionTypeToUpdate);
            logger.LogInformation("TransactionType with ID {Id} successfully updated.", id);

            return id;
        }
        catch (KeyNotFoundException ex)
        {
            logger.LogWarning("Update failed. {Message}", ex.Message);
            throw;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while updating TransactionType with ID {Id}", request.Id);
            throw;
        }
    }
}
