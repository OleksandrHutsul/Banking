namespace Banking.Domain.Entities;

public class Transaction
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime TransactionDate { get; set; }
    public int TransactionTypeId { get; set; }
    public int? FromAccountId { get; set; }
    public int ToAccountId { get; set; }

    public virtual Account? FromAccount { get; set; }
    public virtual Account ToAccount { get; set; }
    public virtual TransactionType TransactionType { get; set; }
}
