using AutoMapper;
using Banking.Domain.Entities;
using Banking.Domain.Repositories;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Banking.Application.Accounts.Commands.CreateAccount.Tests;

public class CreateAccountCommandHandlerTests
{
    [Fact()]
    public async Task HandleTest_ForValidCommand_ReturnsCreateAccountId()
    {
        var loggerMock = new Mock<ILogger<CreateAccountCommandHandler>>();
        var mapperMock = new Mock<IMapper>();
        
        var command = new CreateAccountCommand();
        var account = new Account();
        mapperMock.Setup(m => m.Map<Account>(command)).Returns(account);

        var accountRepositoryMock = new Mock<IAccountRepository>();

        accountRepositoryMock
            .Setup(repo => repo.Create(It.IsAny<Account>()))
            .ReturnsAsync(1);

        accountRepositoryMock
            .Setup(repo => repo.IsCardNumberUniqueAsync(It.IsAny<string>()))
            .ReturnsAsync(true);

        var commandHandler = new CreateAccountCommandHandler(loggerMock.Object,
            mapperMock.Object,
            accountRepositoryMock.Object);

        var result = await commandHandler.Handle(command, CancellationToken.None);

        result.Should().Be(1);
    }
}