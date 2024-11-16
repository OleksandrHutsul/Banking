using AutoMapper;
using Banking.Application.TransactionsType.Commands.Dtos;
using Banking.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Banking.Application.TransactionsType.Commands.Queries.GetTransactionTypeById;

public class GetTransactionTypeByIdQueryHandler(ILogger<GetTransactionTypeByIdQueryHandler> logger,
    IMapper mapper,
    ITransactionTypeRepository transactionTypeRepository) : IRequestHandler<GetTransactionTypeByIdQuery, TransactionTypeDto?>
{
    public async Task<TransactionTypeDto?> Handle(GetTransactionTypeByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting transaction type {request.Id}");
        var transactionType = await transactionTypeRepository.GetByIdAsync(request.Id);

        var transactionTypeDto = mapper.Map<TransactionTypeDto?>(transactionType);

        return transactionTypeDto;
    }
}
