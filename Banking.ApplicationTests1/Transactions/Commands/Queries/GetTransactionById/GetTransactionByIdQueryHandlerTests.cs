using Xunit;
using AutoMapper;
using Banking.Application.Transactions.Commands.Dtos;
using Banking.Application.Transactions.Commands.Queries.GetAllTransaction;
using Banking.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using Banking.Domain.Entities;
using FluentAssertions;

namespace Banking.Application.Transactions.Commands.Queries.GetTransactionById.Tests
{
    public class GetTransactionByIdQueryHandlerTests
    {
        [Fact()]
        public async Task HandleTest_ForValidCommand_ReturnsGetByTransactionIds()
        {
            var loggerMock = new Mock<ILogger<GetTransactionByIdQueryHandler>>();
            var mapperMock = new Mock<IMapper>();
            var transactionRepositoryMock = new Mock<ITransactionRepository>();

            var query = new GetTransactionByIdQuery(1);

            var transactions = new Transaction
            {
                Id = 1,
                Amount = 100.0m,
                TransactionDate = DateTime.Now,
                TransactionTypeId = 1,
                ToAccountId = 1
            };

            transactionRepositoryMock
                .Setup(repo => repo.GetByIdAsync(1))
                .ReturnsAsync(transactions);

            var transactionsDto = new TransactionDto
            {
                Id = 1,
                Amount = 100.0m,
                TransactionDate = DateTime.Now,
                TransactionTypeId = 1,
                ToAccountId = 1
            };

            mapperMock
                .Setup(mapper => mapper.Map<TransactionDto?>(transactions))
                .Returns(transactionsDto);

            var queryHandler = new GetTransactionByIdQueryHandler(
                loggerMock.Object,
                mapperMock.Object,
                transactionRepositoryMock.Object);

            var result = await queryHandler.Handle(query, CancellationToken.None);

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(transactionsDto);
        }
    }
}