using MediatR;

namespace Banking.Application.TransactionsType.Commands.UpdateTransactionType;

public class UpdateTransactionTypeCommand: IRequest<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
}
