using Xunit;
using AutoMapper;
using Banking.Domain.Entities;
using Banking.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using FluentAssertions;

namespace Banking.Application.TransactionsType.Commands.CreateTransactionType.Tests;

public class CreateTransactionTypeCommandHandlerTests
{
    [Fact()]
    public async Task HandleTest_ForValidCommand_ReturnsCreateTransactionTypeId()
    {
        var loggerMock = new Mock<ILogger<CreateTransactionTypeCommandHandler>>();
        var mapperMock = new Mock<IMapper>();

        var command = new CreateTransactionTypeCommand();
        var transactionType = new TransactionType 
        {
            Id = 1,
            Name = "test"
        };

        mapperMock.Setup(m => m.Map<TransactionType>(command)).Returns(transactionType);

        var transactionTypeRepositoryMock = new Mock<ITransactionTypeRepository>();

        transactionTypeRepositoryMock
            .Setup(repo => repo.Create(It.IsAny<TransactionType>()))
            .ReturnsAsync(1);

        var commandHandler = new CreateTransactionTypeCommandHandler(loggerMock.Object,
            mapperMock.Object,
            transactionTypeRepositoryMock.Object);

        var result = await commandHandler.Handle(command, CancellationToken.None);

        result.Should().Be(1);
    }
}