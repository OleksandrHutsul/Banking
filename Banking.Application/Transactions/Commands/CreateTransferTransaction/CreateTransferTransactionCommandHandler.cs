using AutoMapper;
using Banking.Domain.Entities;
using Banking.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Banking.Application.Transactions.Commands.CreateTransferTransaction;

public class CreateTransferTransactionCommandHandler(ILogger<CreateTransferTransactionCommandHandler> logger,
    IMapper mapper,
    ITransactionRepository transactionRepository) : IRequestHandler<CreateTransferTransactionCommand, int>
{
    public async Task<int> Handle(CreateTransferTransactionCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Initiating transfer of {request.Amount} from Account {request.FromAccountId} to Account {request.ToAccountId}");

        var transaction = new Transaction
        {
            Amount = request.Amount,
            FromAccountId = request.FromAccountId,
            ToAccountId = request.ToAccountId,
            TransactionTypeId = 2, 
            TransactionDate = DateTime.Now
        };

        var transactionId = await transactionRepository.Transfer(transaction);

        logger.LogInformation($"Transfer completed successfully. Transaction ID: {transactionId}");
        return transactionId;
    }
}
