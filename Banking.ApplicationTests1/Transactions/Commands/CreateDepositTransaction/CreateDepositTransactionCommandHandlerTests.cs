using Xunit;
using AutoMapper;
using Banking.Domain.Entities;
using Banking.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using FluentAssertions;

namespace Banking.Application.Transactions.Commands.CreateDepositTransaction.Tests
{
    public class CreateDepositTransactionCommandHandlerTests
    {
        [Fact()]
        public async Task HandleTest_ForValidCommand_ReturnsCreateDepositTransactionId()
        {
            var loggerMock = new Mock<ILogger<CreateDepositTransactionCommandHandler>>();
            var mapperMock = new Mock<IMapper>();
            var transactionRepositoryMock = new Mock<ITransactionRepository>();

            var command = new CreateDepositTransactionCommand
            {
                Amount = 1000.00m,
                ToAccountId = 1
            };

            var transaction = new Transaction
            {
                Amount = command.Amount,
                ToAccountId = command.ToAccountId,
                TransactionTypeId = 1,
                TransactionDate = DateTime.Now
            };

            mapperMock
                .Setup(mapper => mapper.Map<Transaction>(command))
                .Returns(transaction);

            transactionRepositoryMock
                .Setup(repo => repo.Deposit(It.IsAny<Transaction>()))
                .ReturnsAsync(1);

            var commandHandler = new CreateDepositTransactionCommandHandler(
                loggerMock.Object,
                mapperMock.Object,
                transactionRepositoryMock.Object);

            var result = await commandHandler.Handle(command, CancellationToken.None);

            result.Should().Be(1);
        }
    }
}