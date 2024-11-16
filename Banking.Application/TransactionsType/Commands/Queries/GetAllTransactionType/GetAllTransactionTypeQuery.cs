using Banking.Application.TransactionsType.Commands.Dtos;
using MediatR;

namespace Banking.Application.TransactionsType.Commands.Queries.GetAllTransactionType;

public class GetAllTransactionTypeQuery: IRequest<IEnumerable<TransactionTypeDto>>
{
}
