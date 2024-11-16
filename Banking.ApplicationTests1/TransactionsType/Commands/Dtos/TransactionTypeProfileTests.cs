using Xunit;
using AutoMapper;
using Banking.Domain.Entities;
using FluentAssertions;
using Banking.Application.TransactionsType.Commands.CreateTransactionType;
using Banking.Application.TransactionsType.Commands.UpdateTransactionType;

namespace Banking.Application.TransactionsType.Commands.Dtos.Tests;

public class TransactionTypeProfileTests
{
    private IMapper _mapper;

    public TransactionTypeProfileTests()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<TransactionTypeProfile>();
        });

        _mapper = configuration.CreateMapper();
    }

    [Fact()]
    public void CreateMap_ForTransactionTypeToTransactionTypeDto_MapsCorrectly()
    {
        var transactionType = new TransactionType
        {
            Id = 1,
            Name = "Test"
        };

        var transactionTypeDto = _mapper.Map<TransactionTypeDto>(transactionType);

        transactionTypeDto.Should().NotBeNull();
        transactionTypeDto.Id.Should().Be(transactionType.Id);
        transactionTypeDto.Name.Should().Be(transactionType.Name);
    }

    [Fact()]
    public void CreateMap_ForCreateTransactionTypeCommandToTransactionType_MapsCorrectly()
    {
        var command = new CreateTransactionTypeCommand
        {
            Id = 1,
            Name = "Test"
        };

        var transactionType = _mapper.Map<TransactionType>(command);

        transactionType.Should().NotBeNull();
        transactionType.Id.Should().Be(command.Id);
        transactionType.Name.Should().Be(command.Name);
    }

    [Fact()]
    public void CreateMap_ForUpdateTransactionTypeCommandToTransactionType_MapsCorrectly()
    {
        var command = new UpdateTransactionTypeCommand
        {
            Id = 1,
            Name = "Up Test"
        };

        var transactionType = _mapper.Map<TransactionType>(command);

        transactionType.Should().NotBeNull();
        transactionType.Id.Should().Be(command.Id);
        transactionType.Name.Should().Be(command.Name);
    }
}