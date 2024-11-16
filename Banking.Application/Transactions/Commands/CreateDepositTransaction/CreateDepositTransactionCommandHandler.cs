using AutoMapper;
using Banking.Domain.Entities;
using Banking.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Banking.Application.Transactions.Commands.CreateDepositTransaction;

public class CreateDepositTransactionCommandHandler(ILogger<CreateDepositTransactionCommandHandler> logger,
    IMapper mapper,
    ITransactionRepository transactionRepository) : IRequestHandler<CreateDepositTransactionCommand, int>
{
    public async Task<int> Handle(CreateDepositTransactionCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Processing deposit of {request.Amount} to account {request.ToAccountId}");

        var transaction = new Transaction
        {
            Amount = request.Amount,
            ToAccountId = request.ToAccountId,
            TransactionTypeId = 1,
            TransactionDate = DateTime.Now
        };

        var transactionId = await transactionRepository.Deposit(transaction);

        logger.LogInformation($"Deposit successful. Transaction ID: {transactionId}");
        return transactionId;
    }
}
