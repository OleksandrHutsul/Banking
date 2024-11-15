using Banking.Application.Accounts.Commands.Dtos;
using MediatR;

namespace Banking.Application.Accounts.Commands.Queries.GetByIdAccount;

public class GetByIdAccountQuery(int id) : IRequest<AccountDto?>
{
    public int Id { get; set; } = id;
}
