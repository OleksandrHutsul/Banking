using AutoMapper;
using Banking.Domain.Entities;
using Banking.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Banking.Application.Accounts.Commands.CreateAccount;

public class CreateAccountCommandHandler(ILogger<CreateAccountCommandHandler> logger,
    IMapper mapper,
    IAccountRepository accountRepository) : IRequestHandler<CreateAccountCommand, int>
{
    public async Task<int> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all accounts");

        var restaurant = mapper.Map<Account>(request);

        int id = await accountRepository.Create(restaurant);

        return id;
    }
}
