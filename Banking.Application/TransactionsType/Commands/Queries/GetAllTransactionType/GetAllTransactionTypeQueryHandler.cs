using AutoMapper;
using Banking.Application.TransactionsType.Commands.Dtos;
using Banking.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Banking.Application.TransactionsType.Commands.Queries.GetAllTransactionType;

public class GetAllTransactionTypeQueryHandler(ILogger<GetAllTransactionTypeQueryHandler> logger,
    IMapper mapper,
    ITransactionTypeRepository transactionTypeRepository) : IRequestHandler<GetAllTransactionTypeQuery, IEnumerable<TransactionTypeDto>>
{
    public async Task<IEnumerable<TransactionTypeDto>> Handle(GetAllTransactionTypeQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all transactions type");
        var transactionTypes = await transactionTypeRepository.GetAllAsync();

        var transactionTypesDto = mapper.Map<IEnumerable<TransactionTypeDto>>(transactionTypes);

        return transactionTypesDto!;
    }
}
