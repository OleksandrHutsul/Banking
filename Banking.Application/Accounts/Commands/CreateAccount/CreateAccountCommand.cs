using MediatR;

namespace Banking.Application.Accounts.Commands.CreateAccount;

public class CreateAccountCommand: IRequest<int>
{
    public int Id { get; set; }
    //public decimal Balance { get; set; }
    //public DateTime CreatedDate { get; set; }
    public int UserId { get; set; }
    //public string CardNumber { get; set; }
}