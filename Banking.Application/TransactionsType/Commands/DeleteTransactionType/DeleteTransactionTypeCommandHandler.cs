using AutoMapper;
using Banking.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Banking.Application.TransactionsType.Commands.DeleteTransactionType;

public class DeleteTransactionTypeCommandHandler(ILogger<DeleteTransactionTypeCommandHandler> logger,
    IMapper mapper,
    ITransactionTypeRepository transactionTypeRepository) : IRequestHandler<DeleteTransactionTypeCommand, bool>
{
    public async Task<bool> Handle(DeleteTransactionTypeCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Deleting transaction type with id : {request.Id}");
        var transactionType = await transactionTypeRepository.GetByIdAsync(request.Id);
        if (transactionType is null)
        {
            return false;
        }

        await transactionTypeRepository.Delete(transactionType);
        return true;
    }
}
