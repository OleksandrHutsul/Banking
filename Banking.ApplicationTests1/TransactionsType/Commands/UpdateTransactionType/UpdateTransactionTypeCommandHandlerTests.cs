using AutoMapper;
using Banking.Domain.Entities;
using Banking.Domain.Repositories;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Banking.Application.TransactionsType.Commands.UpdateTransactionType.Tests;

public class UpdateTransactionTypeCommandHandlerTests
{
    private readonly Mock<ILogger<UpdateTransactionTypeCommandHandler>> _loggerMock;
    private readonly Mock<ITransactionTypeRepository> _transactionTypeRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly UpdateTransactionTypeCommandHandler _handler;

    public UpdateTransactionTypeCommandHandlerTests()
    {
        _loggerMock = new Mock<ILogger<UpdateTransactionTypeCommandHandler>>();
        _mapperMock = new Mock<IMapper>();
        _transactionTypeRepositoryMock = new Mock<ITransactionTypeRepository>();

        _handler = new UpdateTransactionTypeCommandHandler(_loggerMock.Object, 
            _mapperMock.Object,
            _transactionTypeRepositoryMock.Object);
    }

    [Fact()]
    public async Task Handle_WithValidRequest_ShouldUpdateTransactionType()
    {
        var transactionTypeId = 1;
        var command = new UpdateTransactionTypeCommand
        {
            Id = transactionTypeId,
            Name = "new test"
        };

        var transactionType = new TransactionType()
        {
            Id = transactionTypeId,
            Name = "test",
        };

        _mapperMock.Setup(m => m.Map<TransactionType>(command)).Returns(transactionType);
        _transactionTypeRepositoryMock.Setup(t => t.Update(transactionType)).ReturnsAsync(transactionTypeId);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.Should().Be(transactionTypeId);
    }
}