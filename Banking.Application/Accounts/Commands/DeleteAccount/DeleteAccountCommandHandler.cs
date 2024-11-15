using AutoMapper;
using Banking.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Banking.Application.Accounts.Commands.DeleteAccount;

public class DeleteAccountCommandHandler(ILogger<DeleteAccountCommandHandler> logger,
    IMapper mapper,
    IAccountRepository accountRepository) : IRequestHandler<DeleteAccountCommand, bool>
{
    public async Task<bool> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Deleting account with id : {request.Id}");
        var account = await accountRepository.GetByIdAsync(request.Id);
        if (account is null)
        {
            return false;
        }

        await accountRepository.Delete(account);
        return true;
    }
}
