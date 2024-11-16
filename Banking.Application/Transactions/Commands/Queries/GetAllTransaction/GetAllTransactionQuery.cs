using Banking.Application.Transactions.Commands.Dtos;
using MediatR;

namespace Banking.Application.Transactions.Commands.Queries.GetAllTransaction;

public class GetAllTransactionQuery: IRequest<IEnumerable<TransactionDto>>
{
}