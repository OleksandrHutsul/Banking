using Banking.Application.Accounts.Commands.Dtos;
using Banking.Application.TransactionsType.Commands.Dtos;

namespace Banking.Application.Transactions.Commands.Dtos;

public class TransactionDto
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime TransactionDate { get; set; }
    public int TransactionTypeId { get; set; }
    public int? FromAccountId { get; set; }
    public int ToAccountId { get; set; }

    public virtual AccountDto FromAccount { get; set; }
    public virtual AccountDto ToAccount { get; set; }
    public virtual TransactionTypeDto TransactionType { get; set; }
}
