using Banking.Application.Users.Commands.CreateUser;
using MediatR;

namespace Banking.Application.TransactionsType.Commands.CreateTransactionType;

public class CreateTransactionTypeCommandHandler : IRequestHandler<CreateTransactionTypeCommand, int>
{
    public Task<int> Handle(CreateTransactionTypeCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
