using AutoMapper;
using Banking.Application.Accounts.Commands.Dtos;
using Banking.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Banking.Application.Accounts.Commands.Queries.GetByIdAccount;

public class GetByIdAccountQueryHandler(ILogger<GetByIdAccountQueryHandler> logger,
    IMapper mapper,
    IAccountRepository accountRepository) : IRequestHandler<GetByIdAccountQuery, AccountDto?>
{
    public async Task<AccountDto?> Handle(GetByIdAccountQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting restaurant {request.Id}");
        var account = await accountRepository.GetByIdAsync(request.Id);

        var accountDto = mapper.Map<AccountDto?>(account);

        return accountDto;
    }
}