using Banking.Application.Accounts.Commands.Dtos;
using MediatR;

namespace Banking.Application.Accounts.Commands.Queries.GetAllAccounts;

public class GetAllAccountsQuery: IRequest<IEnumerable<AccountDto>>
{
}