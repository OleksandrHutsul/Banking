using FluentValidation.TestHelper;
using Xunit;

namespace Banking.Application.Users.Commands.CreateUser.Tests;

public class CreateUserCommandValidatorTests
{
    [Fact()]
    public void Validator_ForValidCommand_ShouldNotHaveValidationErrors()
    {
        var command = new CreateUserCommand()
        {
            Name = "Kiril",
            LastName = "Sudakov",
            Birthday = new DateTime(2000, 11, 16),
            Phone = "+380977600280"
        };

        var validator = new CreateUserCommandValidator();

        var result = validator.TestValidate(command);

        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact()]
    public void Validator_ForInvalidCommand_ShouldHaveValidationErrors()
    {
        var command = new CreateUserCommand()
        {
            Name = "Kiril",
            LastName = "Sudakov",
            Birthday = new DateTime(2020, 11, 16),
            Phone = "+380977600280"
        };

        var validator = new CreateUserCommandValidator();

        var result = validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(b => b.Birthday);
    }
}