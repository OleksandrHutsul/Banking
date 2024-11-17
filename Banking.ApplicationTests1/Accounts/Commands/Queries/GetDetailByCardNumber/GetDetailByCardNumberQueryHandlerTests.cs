using Xunit;
using Banking.Application.Accounts.Commands.Queries.GetDetailByCardNumber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Banking.Application.Accounts.Commands.Dtos;
using Banking.Application.Accounts.Commands.Queries.GetByIdAccount;
using Banking.Domain.Entities;
using Banking.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using FluentAssertions;

namespace Banking.Application.Accounts.Commands.Queries.GetDetailByCardNumber.Tests
{
    public class GetDetailByCardNumberQueryHandlerTests
    {
        [Fact()]
        public async Task HandleTest_ForValidCommand_ReturnsGetAllAccountIds()
        {
            var loggerMock = new Mock<ILogger<GetDetailByCardNumberQueryHandler>>();
            var mapperMock = new Mock<IMapper>();
            var accountRepositoryMock = new Mock<IAccountRepository>();

            var query = new GetDetailByCardNumberQuery("1234567890");

            var account = new Account { Id = 1, UserId = 100, CardNumber = "1234567890" };
            accountRepositoryMock
                .Setup(repo => repo.GetDetailByCardNumberAsync(query.CardNumber))
                .ReturnsAsync(account);

            var accountDto = new AccountDto { Id = 1, UserId = 100, CardNumber = "1234567890" };
            mapperMock
                .Setup(mapper => mapper.Map<AccountDto?>(account))
                .Returns(accountDto);

            var queryHandler = new GetDetailByCardNumberQueryHandler(
                loggerMock.Object,
                mapperMock.Object,
                accountRepositoryMock.Object);

            var result = await queryHandler.Handle(query, CancellationToken.None);

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(accountDto);
        }
    }
}