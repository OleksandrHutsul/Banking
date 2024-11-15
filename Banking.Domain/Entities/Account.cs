namespace Banking.Domain.Entities;

public class Account
{
    public int Id { get; set; }
    public decimal Balance { get; set; }
    public DateTime CreatedDate { get; set; }
    public int UserId { get; set; }
    public string CardNumber { get; set; }

    public virtual User User { get; set; }
    public virtual ICollection<Transaction>? Transactions { get; set; } = new List<Transaction>();
}
