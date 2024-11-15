using MediatR;

namespace Banking.Application.TransactionsType.Commands.CreateTransactionType;

public class CreateTransactionTypeCommand: IRequest<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
}
