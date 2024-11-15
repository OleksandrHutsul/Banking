using Banking.Application.Transactions.Commands.Dtos;
using Banking.Application.Users.Commands.Dtos;

namespace Banking.Application.Accounts.Commands.Dtos
{
    public class AccountDto
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public string CardNumber { get; set; }

        public virtual UserDto User { get; set; }
        public virtual ICollection<TransactionDto>? Transactions { get; set; } = new List<TransactionDto>();
    }
}
