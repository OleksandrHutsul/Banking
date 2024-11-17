using AutoMapper;
using Banking.Application.TransactionsType.Commands.Dtos;
using Banking.Application.TransactionsType.Commands.Queries.GetTransactionTypeById;
using Banking.Application.Users.Commands.Dtos;
using Banking.Domain.Entities;
using Banking.Domain.Repositories;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Banking.Application.Users.Commands.Queries.GetUserById.Tests;

public class GetUserByIdQueryHandlerTests
{
    [Fact()]
    public async Task HandleTest_ForValidCommand_ReturnsGetUserByIdId()
    {
        var loggerMock = new Mock<ILogger<GetUserByIdQueryHandler>>();
        var mapperMock = new Mock<IMapper>();
        var userRepositoryMock = new Mock<IUserRepository>();

        var query = new GetUserByIdQuery(1);

        var user = new User { Id = 1, Name = "test1", LastName = "test1", Birthday = DateTime.UtcNow, Phone = "+380977600280" };
        userRepositoryMock
            .Setup(repo => repo.GetByIdAsync(query.Id))
            .ReturnsAsync(user);

        var userDto = new UserDto { Id = 1, Name = "test1" };
        mapperMock
            .Setup(mapper => mapper.Map<UserDto?>(user))
            .Returns(userDto);

        var queryHandler = new GetUserByIdQueryHandler(
            loggerMock.Object,
            mapperMock.Object,
            userRepositoryMock.Object);

        var result = await queryHandler.Handle(query, CancellationToken.None);

        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(userDto);
    }
}