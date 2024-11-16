using Xunit;
using Banking.Application.Accounts.Commands.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Banking.Application.Users.Commands.CreateUser;
using Banking.Application.Users.Commands.Dtos;
using Banking.Domain.Entities;
using FluentAssertions;
using Banking.Application.Accounts.Commands.CreateAccount;

namespace Banking.Application.Accounts.Commands.Dtos.Tests
{
    public class AccountProfileTests
    {
        private IMapper _mapper;

        public AccountProfileTests()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AccountProfile>();
            });

            _mapper = configuration.CreateMapper();
        }

        [Fact()]
        public void CreateMap_ForAccountToAccountDto_MapsCorrectly()
        {
            var account = new Account
            {
                Id = 1,
                Balance = 10000,
                CreatedDate = DateTime.Now,
                UserId = 1,
                CardNumber = "2000 2000 2000 2000"
            };

            var accountDto = _mapper.Map<AccountDto>(account);

            accountDto.Should().NotBeNull();
            accountDto.Id.Should().Be(account.Id);
            accountDto.Balance.Should().Be(account.Balance);
            accountDto.CreatedDate.Should().Be(account.CreatedDate);
            accountDto.UserId.Should().Be(account.UserId);
            accountDto.CardNumber.Should().Be(account.CardNumber);
        }

        [Fact()]
        public void CreateMap_ForCreateAccountCommandToAccount_MapsCorrectly()
        {
            var command = new CreateAccountCommand
            {
                Id = 1,
                UserId = 2
            };

            var account = _mapper.Map<Account>(command);

            account.Should().NotBeNull();
            account.Id.Should().Be(command.Id);
            account.UserId.Should().Be(command.UserId);
        }
    }
}