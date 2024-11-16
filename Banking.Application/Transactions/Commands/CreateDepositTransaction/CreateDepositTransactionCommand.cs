using MediatR;

namespace Banking.Application.Transactions.Commands.CreateDepositTransaction;

public class CreateDepositTransactionCommand: IRequest<int>
{
    public decimal Amount { get; set; }
    public int ToAccountId { get; set; }
}
