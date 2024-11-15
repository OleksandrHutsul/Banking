using MediatR;

namespace Banking.Application.Users.Commands.CreateUser;

public class CreateUserCommand: IRequest<int>
{
    public int Id { get; set; }
    public decimal Balance { get; set; }
    public DateTime CreatedDate { get; set; }
    public int UserId { get; set; }
}
