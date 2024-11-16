using Banking.Application.Accounts.Commands.Dtos;
using MediatR;

namespace Banking.Application.Accounts.Commands.Queries.GetDetailByCardNumber;

public class GetDetailByCardNumberQuery(string cardNumber) : IRequest<AccountDto?>
{
    public string CardNumber { get; set; } = cardNumber;
}
