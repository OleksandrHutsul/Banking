using AutoMapper;
using Banking.Application.Transactions.Commands.CreateTransaction;
using Banking.Domain.Entities;

namespace Banking.Application.TransactionsType.Commands.Dtos;

public class TransactionTypeProfile: Profile
{
    public TransactionTypeProfile()
    {
        CreateMap<CreateTransactionCommand, TransactionType>();
        CreateMap<TransactionType, TransactionTypeDto>();
    }
}
