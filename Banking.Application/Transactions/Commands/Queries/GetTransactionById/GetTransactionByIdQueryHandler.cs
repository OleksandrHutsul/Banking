using AutoMapper;
using Banking.Application.Transactions.Commands.Dtos;
using Banking.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Banking.Application.Transactions.Commands.Queries.GetTransactionById;

public class GetTransactionByIdQueryHandler(ILogger<GetTransactionByIdQueryHandler> logger,
    IMapper mapper,
    ITransactionRepository transactionRepository) : IRequestHandler<GetTransactionByIdQuery, TransactionDto?>
{
    public async Task<TransactionDto?> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting account {request.Id}");
        var transaction = await transactionRepository.GetByIdAsync(request.Id);

        var transactionDto = mapper.Map<TransactionDto?>(transaction);

        return transactionDto;
    }
}
