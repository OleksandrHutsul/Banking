using MediatR;

namespace Banking.Application.Users.Commands.CreateUser;

public class CreateUserCommand: IRequest<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime Birthday { get; set; }
    public string Phone { get; set; }
}
