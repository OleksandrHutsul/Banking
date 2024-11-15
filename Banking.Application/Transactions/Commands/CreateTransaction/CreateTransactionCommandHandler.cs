using MediatR;

namespace Banking.Application.Transactions.Commands.CreateTransaction;

public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, int>
{
    public Task<int> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
