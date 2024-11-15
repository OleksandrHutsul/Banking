using AutoMapper;
using Banking.Application.Transactions.Commands.CreateTransaction;
using Banking.Domain.Entities;

namespace Banking.Application.Transactions.Commands.Dtos;

public class TransactionProfile: Profile
{
    public TransactionProfile()
    {
        CreateMap<CreateTransactionCommand, Transaction>();
        CreateMap<Transaction, TransactionDto>();
    }
}
