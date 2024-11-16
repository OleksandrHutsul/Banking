using Xunit;
using AutoMapper;
using Banking.Domain.Entities;
using FluentAssertions;
using Banking.Application.Transactions.Commands.CreateDepositTransaction;
using Banking.Application.Transactions.Commands.CreateTransferTransaction;
using Banking.Application.Transactions.Commands.CreateWithdrawTransaction;

namespace Banking.Application.Transactions.Commands.Dtos.Tests;

public class TransactionProfileTests
{
    private IMapper _mapper;

    public TransactionProfileTests()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<TransactionProfile>();
        });

        _mapper = configuration.CreateMapper();
    }

    [Fact()]
    public void CreateMap_ForTransactionToTransactionDto_MapsCorrectly()
    {
        var transaction = new Transaction
        {
            Id = 1,
            Amount = 20000,
            TransactionDate = DateTime.Now,
            TransactionTypeId = 1,
            FromAccountId = 1,
            ToAccountId = 2,
        };

        var transactionDto = _mapper.Map<TransactionDto>(transaction);

        transactionDto.Should().NotBeNull();
        transactionDto.Id.Should().Be(transaction.Id);
        transactionDto.Amount.Should().Be(transaction.Amount);
        transactionDto.TransactionTypeId.Should().Be(transaction.TransactionTypeId);
        transactionDto.FromAccountId.Should().Be(transaction.FromAccountId);
        transactionDto.ToAccountId.Should().Be(transaction.ToAccountId);
    }

    [Fact()]
    public void CreateMap_ForCreateDepositTransactionToTransaction_MapsCorrectly()
    {
        var command = new CreateDepositTransactionCommand
        {
            Amount = 20000,
            ToAccountId = 2,
        };

        var transaction = _mapper.Map<Transaction>(command);

        transaction.Should().NotBeNull();
        transaction.Amount.Should().Be(command.Amount);
        transaction.ToAccountId.Should().Be(command.ToAccountId);
    }

    [Fact()]
    public void CreateMap_ForCreateWithdrawTransactionToTransaction_MapsCorrectly()
    {
        var command = new CreateWithdrawTransactionCommand
        {
            Amount = 20000,
            ToAccountId = 2,
        };

        var transaction = _mapper.Map<Transaction>(command);

        transaction.Should().NotBeNull();
        transaction.Amount.Should().Be(command.Amount);
        transaction.ToAccountId.Should().Be(command.ToAccountId);
    }

    [Fact()]
    public void CreateMap_ForCreateTransferTransactionToTransaction_MapsCorrectly()
    {
        var command = new CreateTransferTransactionCommand
        {
            Amount = 20000,
            FromAccountId = 3,
            ToAccountId = 2,
        };

        var transaction = _mapper.Map<Transaction>(command);

        transaction.Should().NotBeNull();
        transaction.Amount.Should().Be(command.Amount);
        transaction.FromAccountId.Should().Be(command.FromAccountId);
        transaction.ToAccountId.Should().Be(command.ToAccountId);
    }
}