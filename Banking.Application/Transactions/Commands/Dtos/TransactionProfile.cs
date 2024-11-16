using AutoMapper;
using Banking.Application.Transactions.Commands.CreateDepositTransaction;
using Banking.Application.Transactions.Commands.CreateTransferTransaction;
using Banking.Application.Transactions.Commands.CreateWithdrawTransaction;
using Banking.Domain.Entities;

namespace Banking.Application.Transactions.Commands.Dtos;

public class TransactionProfile: Profile
{
    public TransactionProfile()
    {
        CreateMap<CreateWithdrawTransactionCommand, Transaction>();
        CreateMap<CreateDepositTransactionCommand, Transaction>();
        CreateMap<CreateTransferTransactionCommand, Transaction>();
        CreateMap<Transaction, TransactionDto>();
    }
}
