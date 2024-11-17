using AutoMapper;
using Banking.Domain.Entities;
using Banking.Domain.Repositories;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Banking.Application.Accounts.Commands.DeleteAccount.Tests;

public class DeleteAccountCommandHandlerTests
{
    [Fact()]
    public async Task HandleTest_ForValidCommand_ReturnsDeleteAccountBool()
    {
        var loggerMock = new Mock<ILogger<DeleteAccountCommandHandler>>();
        var accountRepositoryMock = new Mock<IAccountRepository>();

        var command = new DeleteAccountCommand(1);
        var account = new Account { Id = 1 };

        accountRepositoryMock
            .Setup(repo => repo.GetByIdAsync(command.Id))
            .ReturnsAsync(account); 

        accountRepositoryMock
            .Setup(repo => repo.Delete(account))
            .Returns(Task.CompletedTask); 

        var commandHandler = new DeleteAccountCommandHandler(
            loggerMock.Object,
            Mock.Of<IMapper>(), 
            accountRepositoryMock.Object);

        var result = await commandHandler.Handle(command, CancellationToken.None);

        result.Should().Be(true);
    }
}