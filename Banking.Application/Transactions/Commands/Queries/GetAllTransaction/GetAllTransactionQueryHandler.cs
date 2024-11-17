using AutoMapper;
using Banking.Application.Transactions.Commands.Dtos;
using Banking.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Banking.Application.Transactions.Commands.Queries.GetAllTransaction;

public class GetAllTransactionQueryHandler(ILogger<GetAllTransactionQueryHandler> logger,
    IMapper mapper,
    ITransactionRepository transactionRepository) : IRequestHandler<GetAllTransactionQuery, IEnumerable<TransactionDto>>
{
    public async Task<IEnumerable<TransactionDto>> Handle(GetAllTransactionQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all transactions");
        var transactions = await transactionRepository.GetAllAsync();

        var transactionsDtos = mapper.Map<IEnumerable<TransactionDto>>(transactions);

        return transactionsDtos!;
    }
}
