using AutoMapper;
using Banking.Application.Accounts.Commands.Dtos;
using Banking.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Banking.Application.Accounts.Commands.Queries.GetAllAccounts;

public class GetAllAccountsQueryHandler(ILogger<GetAllAccountsQueryHandler> logger,
    IMapper mapper,
    IAccountRepository accountsRepository) : IRequestHandler<GetAllAccountsQuery, IEnumerable<AccountDto>>
{
    public async Task<IEnumerable<AccountDto>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all accounts");
        var accounts = await accountsRepository.GetAllAsync();

        var accountsDtos = mapper.Map<IEnumerable<AccountDto>>(accounts);

        return accountsDtos!;
    }
}
