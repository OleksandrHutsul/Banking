using AutoMapper;
using Banking.Application.Accounts.Commands.CreateAccount;
using Banking.Domain.Entities;

namespace Banking.Application.Accounts.Commands.Dtos;

public class AccountProfile: Profile
{
    public AccountProfile()
    {
        CreateMap<CreateAccountCommand, Account>();
        CreateMap<Account, AccountDto>();
    }
}
