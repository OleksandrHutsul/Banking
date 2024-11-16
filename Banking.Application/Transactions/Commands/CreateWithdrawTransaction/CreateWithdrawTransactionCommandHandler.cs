using AutoMapper;
using Banking.Domain.Entities;
using Banking.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Banking.Application.Transactions.Commands.CreateWithdrawTransaction;

public class CreateWithdrawTransactionCommandHandler(ILogger<CreateWithdrawTransactionCommandHandler> logger,
    IMapper mapper,
    ITransactionRepository transactionRepository) : IRequestHandler<CreateWithdrawTransactionCommand, int>
{
    public async Task<int> Handle(CreateWithdrawTransactionCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Processing withdraw of {request.Amount} to account {request.ToAccountId}");

        var transaction = new Transaction
        {
            Amount = request.Amount,
            ToAccountId = request.ToAccountId,
            TransactionTypeId = 3, 
            TransactionDate = DateTime.Now
        };

        var transactionId = await transactionRepository.Withdraw(transaction);

        logger.LogInformation($"Withdraw successful. Transaction ID: {transactionId}");
        return transactionId;
    }
}
