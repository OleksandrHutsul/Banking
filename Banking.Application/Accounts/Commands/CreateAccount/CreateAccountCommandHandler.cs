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
        logger.LogInformation("Creating a new accounts");

        string cardNumber;
        do
        {
            cardNumber = CardNumberGenerator.GenerateCardNumber();
        } while (!await accountRepository.IsCardNumberUniqueAsync(cardNumber));

        var account = new Account
        {
            UserId = request.UserId,
            CardNumber = cardNumber
        };

        int id = await accountRepository.Create(account);

        return id;
    }
}
