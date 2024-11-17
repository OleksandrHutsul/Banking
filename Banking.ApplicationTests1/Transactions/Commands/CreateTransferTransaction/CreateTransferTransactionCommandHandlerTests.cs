using Xunit;
using AutoMapper;
using Banking.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using Banking.Domain.Entities;
using FluentAssertions;

namespace Banking.Application.Transactions.Commands.CreateTransferTransaction.Tests
{
    public class CreateTransferTransactionCommandHandlerTests
    {
        [Fact()]
        public async Task HandleTest_ForValidCommand_ReturnsCreateTransferTransactionId()
        {
            var loggerMock = new Mock<ILogger<CreateTransferTransactionCommandHandler>>();
            var mapperMock = new Mock<IMapper>();
            var transactionRepositoryMock = new Mock<ITransactionRepository>();

            var command = new CreateTransferTransactionCommand
            {
                Amount = 1000.00m,
                FromAccountId = 2,
                ToAccountId = 1
            };

            var transaction = new Transaction
            {
                Amount = command.Amount,
                FromAccountId = command.FromAccountId,
                ToAccountId = command.ToAccountId,
                TransactionTypeId = 2,
                TransactionDate = DateTime.UtcNow
            };

            mapperMock
                .Setup(mapper => mapper.Map<Transaction>(command))
                .Returns(transaction);

            transactionRepositoryMock
                .Setup(repo => repo.Transfer(It.IsAny<Transaction>()))
                .ReturnsAsync(1);

            var commandHandler = new CreateTransferTransactionCommandHandler(
                loggerMock.Object,
                mapperMock.Object,
                transactionRepositoryMock.Object);

            var result = await commandHandler.Handle(command, CancellationToken.None);

            result.Should().Be(1);
        }
    }
}