using Xunit;
using AutoMapper;
using Banking.Domain.Entities;
using Banking.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using Banking.Application.TransactionsType.Commands.Dtos;
using FluentAssertions;

namespace Banking.Application.TransactionsType.Commands.Queries.GetTransactionTypeById.Tests;

public class GetTransactionTypeByIdQueryHandlerTests
{
    [Fact()]
    public async Task HandleTest_ForValidCommand_ReturnsGetTransactionTypeByIdId()
    {
        var loggerMock = new Mock<ILogger<GetTransactionTypeByIdQueryHandler>>();
        var mapperMock = new Mock<IMapper>();
        var transactionTypeRepositoryMock = new Mock<ITransactionTypeRepository>();

        var query = new GetTransactionTypeByIdQuery(1);

        var transactionType = new TransactionType { Id = 1, Name = "test1" };
        transactionTypeRepositoryMock
            .Setup(repo => repo.GetByIdAsync(query.Id))
            .ReturnsAsync(transactionType);

        var transactionTypeDto = new TransactionTypeDto { Id = 1, Name = "test1" };
        mapperMock
            .Setup(mapper => mapper.Map<TransactionTypeDto?>(transactionType))
            .Returns(transactionTypeDto);

        var queryHandler = new GetTransactionTypeByIdQueryHandler(
            loggerMock.Object,
            mapperMock.Object,
            transactionTypeRepositoryMock.Object);

        var result = await queryHandler.Handle(query, CancellationToken.None);

        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(transactionTypeDto);
    }
}