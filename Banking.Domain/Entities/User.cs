namespace Banking.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime Birthday { get; set; }
    public string Phone { get; set; }

    public virtual ICollection<Account>? Accounts { get; set; } = new List<Account>();
}
