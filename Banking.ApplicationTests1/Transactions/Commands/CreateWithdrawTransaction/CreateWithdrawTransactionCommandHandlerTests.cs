using Xunit;
using AutoMapper;
using Moq;
using Microsoft.Extensions.Logging;
using Banking.Domain.Repositories;
using Banking.Domain.Entities;
using FluentAssertions;

namespace Banking.Application.Transactions.Commands.CreateWithdrawTransaction.Tests
{
    public class CreateWithdrawTransactionCommandHandlerTests
    {
        [Fact()]
        public async Task HandleTest_ForValidCommand_ReturnsCreateWithdrawTransactionId()
        {
            var loggerMock = new Mock<ILogger<CreateWithdrawTransactionCommandHandler>>();
            var mapperMock = new Mock<IMapper>();
            var transactionRepositoryMock = new Mock<ITransactionRepository>();

            var command = new CreateWithdrawTransactionCommand
            {
                Amount = 1000.00m,
                ToAccountId = 1
            };

            var transaction = new Transaction
            {
                Amount = command.Amount,
                ToAccountId = command.ToAccountId,
                TransactionTypeId = 3,
                TransactionDate = DateTime.UtcNow
            };

            mapperMock
                .Setup(mapper => mapper.Map<Transaction>(command))
                .Returns(transaction);

            transactionRepositoryMock
                .Setup(repo => repo.Withdraw(It.IsAny<Transaction>()))
                .ReturnsAsync(1);

            var commandHandler = new CreateWithdrawTransactionCommandHandler(
                loggerMock.Object,
                mapperMock.Object,
                transactionRepositoryMock.Object);

            var result = await commandHandler.Handle(command, CancellationToken.None);

            result.Should().Be(1);
        }
    }
}