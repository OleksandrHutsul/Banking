using Xunit;
using AutoMapper;
using Banking.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using Banking.Application.TransactionsType.Commands.Dtos;
using FluentAssertions;
using Banking.Domain.Entities;

namespace Banking.Application.TransactionsType.Commands.Queries.GetAllTransactionType.Tests;

public class GetAllTransactionTypeQueryHandlerTests
{
    [Fact()]
    public async Task HandleTest_ForValidCommand_ReturnsGetAllTransactionTypeIds()
    {
        var loggerMock = new Mock<ILogger<GetAllTransactionTypeQueryHandler>>();
        var mapperMock = new Mock<IMapper>();
        var transactionTypeRepositoryMock = new Mock<ITransactionTypeRepository>();

        var transactions = new List<TransactionType>
        {
            new TransactionType { Id = 1, Name = "test1" },
            new TransactionType { Id = 2, Name = "test2" }
        };

        transactionTypeRepositoryMock
            .Setup(repo => repo.GetAllAsync())
            .ReturnsAsync(transactions);

        var transactionTypeDtos = new List<TransactionTypeDto>
        {
            new TransactionTypeDto { Id = 1, Name = "test1" },
            new TransactionTypeDto { Id = 2, Name = "test2" }
        };

        mapperMock
            .Setup(mapper => mapper.Map<IEnumerable<TransactionTypeDto>>(transactions))
            .Returns(transactionTypeDtos);

        var commandHandler = new GetAllTransactionTypeQueryHandler(
            loggerMock.Object,
            mapperMock.Object,
            transactionTypeRepositoryMock.Object);

        var result = await commandHandler.Handle(new GetAllTransactionTypeQuery(), CancellationToken.None);

        result.Should().BeEquivalentTo(transactionTypeDtos);
    }
}