using Banking.Application.Accounts.Commands.Dtos;

namespace Banking.Application.Users.Commands.Dtos;

public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime Birthday { get; set; }
    public string Phone { get; set; }

    public virtual ICollection<AccountDto>? Accounts { get; set; } = new List<AccountDto>();
}