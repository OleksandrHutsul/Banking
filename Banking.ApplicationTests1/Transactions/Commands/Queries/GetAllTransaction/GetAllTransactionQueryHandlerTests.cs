using AutoMapper;
using Banking.Application.Transactions.Commands.Dtos;
using Banking.Domain.Entities;
using Banking.Domain.Repositories;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Banking.Application.Transactions.Commands.Queries.GetAllTransaction.Tests;

public class GetAllTransactionQueryHandlerTests
{
    [Fact()]
    public async Task HandleTest_ForValidCommand_ReturnsGetAllTransactionIds()
    {
        var loggerMock = new Mock<ILogger<GetAllTransactionQueryHandler>>();
        var mapperMock = new Mock<IMapper>();
        var transactionRepositoryMock = new Mock<ITransactionRepository>();

        var query = new GetAllTransactionQuery();

        var transactions = new List<Transaction>
        { 
            new Transaction 
            {
                Id = 1,
                Amount = 100.0m,
                TransactionDate = DateTime.Now,
                TransactionTypeId = 1,
                ToAccountId = 1
            },
            new Transaction
            {
                Id = 2,
                Amount = 200.0m,
                TransactionDate = DateTime.Now,
                TransactionTypeId = 3,
                ToAccountId = 2
            }
        };

        transactionRepositoryMock
            .Setup(repo => repo.GetAllAsync())
            .ReturnsAsync(transactions);

        var transactionsDto = new List<TransactionDto>
        {
            new TransactionDto
                {
                    Id = 1,
                    Amount = 100.0m,
                    TransactionDate = DateTime.Now,
                    TransactionTypeId = 1,
                    ToAccountId = 1
                },
                new TransactionDto
                {
                    Id = 2,
                    Amount = 200.0m,
                    TransactionDate = DateTime.Now,
                    TransactionTypeId = 3,
                    ToAccountId = 2
                }
        };

        mapperMock
            .Setup(mapper => mapper.Map<IEnumerable<TransactionDto?>>(transactions))
            .Returns(transactionsDto);

        var queryHandler = new GetAllTransactionQueryHandler(
            loggerMock.Object,
            mapperMock.Object,
            transactionRepositoryMock.Object);

        var result = await queryHandler.Handle(query, CancellationToken.None);

        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(transactionsDto);
    }
}