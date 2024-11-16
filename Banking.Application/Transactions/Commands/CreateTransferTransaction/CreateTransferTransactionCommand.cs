using MediatR;

namespace Banking.Application.Transactions.Commands.CreateTransferTransaction;

public class CreateTransferTransactionCommand : IRequest<int>
{
    public decimal Amount { get; set; }
    public int FromAccountId { get; set; }
    public int ToAccountId { get; set; }
}
