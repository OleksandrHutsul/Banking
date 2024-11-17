using Xunit;
using AutoMapper;
using Banking.Domain.Entities;
using Banking.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using Banking.Application.Accounts.Commands.Dtos;
using FluentAssertions;

namespace Banking.Application.Accounts.Commands.Queries.GetAllAccounts.Tests
{
    public class GetAllAccountsQueryHandlerTests
    {
        [Fact()]
        public async Task HandleTest_ForValidCommand_ReturnsGetAllAccountIds()
        {
            var loggerMock = new Mock<ILogger<GetAllAccountsQueryHandler>>();
            var mapperMock = new Mock<IMapper>();
            var accountRepositoryMock = new Mock<IAccountRepository>();

            var accounts = new List<Account>
            {
                new Account { Id = 1, UserId = 1, CardNumber = "1234" },
                new Account { Id = 2, UserId = 2, CardNumber = "5678" }
            };

            accountRepositoryMock
                .Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(accounts);

            var accountsDtos = new List<AccountDto>
            {
                new AccountDto { Id = 1, UserId = 1, CardNumber = "1234" },
                new AccountDto { Id = 2, UserId = 2, CardNumber = "5678" }
            };

            mapperMock
                .Setup(mapper => mapper.Map<IEnumerable<AccountDto>>(accounts))
                .Returns(accountsDtos);

            var commandHandler = new GetAllAccountsQueryHandler(
                loggerMock.Object,
                mapperMock.Object,
                accountRepositoryMock.Object);

            var result = await commandHandler.Handle(new GetAllAccountsQuery(), CancellationToken.None);

            result.Should().BeEquivalentTo(accountsDtos);
        }
    }
}