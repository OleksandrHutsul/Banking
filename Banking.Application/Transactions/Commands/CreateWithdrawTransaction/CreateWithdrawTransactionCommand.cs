using MediatR;

namespace Banking.Application.Transactions.Commands.CreateWithdrawTransaction;

public class CreateWithdrawTransactionCommand: IRequest<int>
{
    public decimal Amount { get; set; }
    public int ToAccountId { get; set; }
}
