using MediatR;

namespace Banking.Application.TransactionsType.Commands.Dtos;

public class TransactionTypeDto: IRequest<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
}
