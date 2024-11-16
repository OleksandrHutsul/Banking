using FluentValidation;

namespace Banking.Application.Users.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(dto => dto.Birthday)
            .Must(BeAtLeast18YearsOld)
            .WithMessage("User must be at least 18 years old.");
    }

    private bool BeAtLeast18YearsOld(DateTime birthday)
    {
        var today = DateTime.UtcNow;
        var age = today.Year - birthday.Year;

        if (birthday.Date > today.AddYears(-age))
        {
            age--;
        }

        return age >= 18;
    }
}