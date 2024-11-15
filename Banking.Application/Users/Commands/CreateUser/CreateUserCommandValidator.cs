using FluentValidation;

namespace Banking.Application.Users.Commands.CreateUser;

public class CreateUserCommandValidator: AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        
    }
}
