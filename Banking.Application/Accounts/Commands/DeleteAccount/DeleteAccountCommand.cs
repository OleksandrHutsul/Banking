using MediatR;

namespace Banking.Application.Accounts.Commands.DeleteAccount;

public class DeleteAccountCommand(int id) : IRequest<bool>
{
    public int Id { get; } = id;
}
