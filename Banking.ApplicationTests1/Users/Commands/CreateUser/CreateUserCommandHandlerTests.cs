using AutoMapper;
using Banking.Domain.Entities;
using Banking.Domain.Repositories;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Banking.Application.Users.Commands.CreateUser.Tests;

public class CreateUserCommandHandlerTests
{
    [Fact()]
    public async Task HandleTest_ForValidCommand_ReturnsCreateUserId()
    {
        var loggerMock = new Mock<ILogger<CreateUserCommandHandler>>();
        var mapperMock = new Mock<IMapper>();

        var command = new CreateUserCommand();
        var user = new User
        {
            Id = 1,
            Name = "test",
            LastName = "test",
            Birthday = DateTime.UtcNow,
            Phone = "+380977600280"
        };

        mapperMock.Setup(m => m.Map<User>(command)).Returns(user);

        var userRepositoryMock = new Mock<IUserRepository>();

        userRepositoryMock
            .Setup(repo => repo.Create(It.IsAny<User>()))
            .ReturnsAsync(1);

        var commandHandler = new CreateUserCommandHandler(loggerMock.Object,
            mapperMock.Object,
            userRepositoryMock.Object);

        var result = await commandHandler.Handle(command, CancellationToken.None);

        result.Should().Be(1);
    }
}