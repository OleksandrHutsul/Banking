using AutoMapper;
using Banking.Application.Accounts.Commands.Dtos;
using Banking.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Banking.Application.Accounts.Commands.Queries.GetDetailByCardNumber;

public class GetDetailByCardNumberQueryHandler(ILogger<GetDetailByCardNumberQueryHandler> logger,
    IMapper mapper,
    IAccountRepository accountRepository) : IRequestHandler<GetDetailByCardNumberQuery, AccountDto?>
{
    public async Task<AccountDto?> Handle(GetDetailByCardNumberQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting account {request.CardNumber}");
        var account = await accountRepository.GetDetailByCardNumberAsync(request.CardNumber);

        var accountDto = mapper.Map<AccountDto?>(account);

        return accountDto;
    }
}
