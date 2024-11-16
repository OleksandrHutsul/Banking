using MediatR;

namespace Banking.Application.TransactionsType.Commands.DeleteTransactionType;

public class DeleteTransactionTypeCommand(int id) : IRequest<bool>
{
    public int Id { get; } = id;
}
