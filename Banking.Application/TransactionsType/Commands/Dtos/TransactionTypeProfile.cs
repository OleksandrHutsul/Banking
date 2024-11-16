using AutoMapper;
using Banking.Application.TransactionsType.Commands.CreateTransactionType;
using Banking.Application.TransactionsType.Commands.UpdateTransactionType;
using Banking.Domain.Entities;

namespace Banking.Application.TransactionsType.Commands.Dtos;

public class TransactionTypeProfile: Profile
{
    public TransactionTypeProfile()
    {
        CreateMap<CreateTransactionTypeCommand, TransactionType>();
        CreateMap<UpdateTransactionTypeCommand, TransactionType>();
        CreateMap<TransactionType, TransactionTypeDto>();
    }
}
