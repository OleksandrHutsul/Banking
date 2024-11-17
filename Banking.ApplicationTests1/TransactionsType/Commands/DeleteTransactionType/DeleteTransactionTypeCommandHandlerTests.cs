using Xunit;
using Microsoft.Extensions.Logging;
using Moq;
using Banking.Domain.Repositories;
using Banking.Domain.Entities;
using AutoMapper;
using FluentAssertions;

namespace Banking.Application.TransactionsType.Commands.DeleteTransactionType.Tests;

public class DeleteTransactionTypeCommandHandlerTests
{
    [Fact()]
    public async Task HandleTest_ForValidCommand_ReturnsDeleteTransactionTypeBool()
    {
        var loggerMock = new Mock<ILogger<DeleteTransactionTypeCommandHandler>>();
        var transactionTypeRepositoryMock = new Mock<ITransactionTypeRepository>();

        var command = new DeleteTransactionTypeCommand(1);
        var transactionType = new TransactionType { Id = 1 };

        transactionTypeRepositoryMock
            .Setup(repo => repo.GetByIdAsync(command.Id))
            .ReturnsAsync(transactionType);

        transactionTypeRepositoryMock
            .Setup(repo => repo.Delete(transactionType))
            .Returns(Task.CompletedTask);

        var commandHandler = new DeleteTransactionTypeCommandHandler(
            loggerMock.Object,
            Mock.Of<IMapper>(),
            transactionTypeRepositoryMock.Object);

        var result = await commandHandler.Handle(command, CancellationToken.None);

        result.Should().Be(true);
    }
}