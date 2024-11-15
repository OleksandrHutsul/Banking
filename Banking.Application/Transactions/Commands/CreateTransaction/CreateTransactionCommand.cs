using MediatR;

namespace Banking.Application.Transactions.Commands.CreateTransaction;

public class CreateTransactionCommand: IRequest<int>
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime TransactionDate { get; set; }
    public int TransactionTypeId { get; set; }
    public int? FromAccountId { get; set; }
    public int ToAccountId { get; set; }
}
