using Banking.Application.Transactions.Commands.Dtos;
using MediatR;

namespace Banking.Application.Transactions.Commands.Queries.GetTransactionById;

public class GetTransactionByIdQuery(int id) : IRequest<TransactionDto?>
{
    public int Id { get; set; } = id;
}
