using Banking.Application.TransactionsType.Commands.Dtos;
using MediatR;

namespace Banking.Application.TransactionsType.Commands.Queries.GetTransactionTypeById;

public class GetTransactionTypeByIdQuery(int id) : IRequest<TransactionTypeDto?>
{
    public int Id { get; set; } = id;
}
