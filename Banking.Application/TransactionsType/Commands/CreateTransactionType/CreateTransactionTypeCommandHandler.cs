using AutoMapper;
using Banking.Domain.Entities;
using Banking.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Banking.Application.TransactionsType.Commands.CreateTransactionType;

public class CreateTransactionTypeCommandHandler(ILogger<CreateTransactionTypeCommandHandler> logger,
    IMapper mapper,
    ITransactionTypeRepository transactionTypeRepository) : IRequestHandler<CreateTransactionTypeCommand, int>
{
    public async Task<int> Handle(CreateTransactionTypeCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating a new transaction type");

        var transactionType = mapper.Map<TransactionType>(request);

        int id = await transactionTypeRepository.Create(transactionType);

        return id;
    }
}