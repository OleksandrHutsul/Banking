using FluentValidation;

namespace Banking.Application.Accounts.Commands.CreateAccount;

public class CreateAccountCommandValidator: AbstractValidator<CreateAccountCommand>
{
    public CreateAccountCommandValidator()
    {
        //RuleFor(dto => dto.)
        //    .Matches(@"^\d{2}-\d{3}$")
        //    .WithMessage("Please provide a valid postal code(XX - XXX)");
    }
}