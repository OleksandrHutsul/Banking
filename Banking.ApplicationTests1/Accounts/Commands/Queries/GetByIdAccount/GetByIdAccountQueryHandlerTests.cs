using Xunit;
using AutoMapper;
using Banking.Domain.Entities;
using Banking.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using FluentAssertions;
using Banking.Application.Accounts.Commands.Dtos;

namespace Banking.Application.Accounts.Commands.Queries.GetByIdAccount.Tests
{
    public class GetByIdAccountQueryHandlerTests
    {
        [Fact()]
        public async Task HandleTest_ForValidCommand_ReturnsGetByIdAccountId()
        {
            var loggerMock = new Mock<ILogger<GetByIdAccountQueryHandler>>();
            var mapperMock = new Mock<IMapper>();
            var accountRepositoryMock = new Mock<IAccountRepository>();

            var query = new GetByIdAccountQuery(1);

            var account = new Account { Id = 1, UserId = 100, CardNumber = "1234567890" };
            accountRepositoryMock
                .Setup(repo => repo.GetByIdAsync(query.Id))
                .ReturnsAsync(account);

            var accountDto = new AccountDto { Id = 1, UserId = 100, CardNumber = "1234567890" };
            mapperMock
                .Setup(mapper => mapper.Map<AccountDto?>(account))
                .Returns(accountDto);

            var queryHandler = new GetByIdAccountQueryHandler(
                loggerMock.Object,
                mapperMock.Object,
                accountRepositoryMock.Object);

            var result = await queryHandler.Handle(query, CancellationToken.None);

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(accountDto);
        }
    }
}