using Xunit;
using Banking.API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;

namespace Banking.API.Controllers.Tests
{
    public class TransactionControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public TransactionControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact()]
        public async Task GetAll_ForValidRequst_Returns200Ok()
        {
            var client = _factory.CreateClient();

            var result = await client.GetAsync("/api/transaction/GetAll");

            result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact()]
        public async Task GetById_ForValidRequst_Returns200Ok()
        {
            var client = _factory.CreateClient();
            var validId = 1;

            var result = await client.GetAsync($"/api/transaction/GetById/{validId}");

            result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact()]
        public async Task CreateDeposit_ForValidRequest_Returns201Created()
        {
            var client = _factory.CreateClient();
            var newDeposit = new
            {
                Amount = 100.0m,
                ToAccountId = 2
            };

            var result = await client.PostAsJsonAsync("/api/transaction/Deposit", newDeposit);

            result.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
        }

        [Fact()]
        public async Task CreateWithdraw_ForValidRequest_Returns201Created()
        {
            var client = _factory.CreateClient();
            var newWithdraw = new
            {
                Amount = 100.0m,
                ToAccountId = 2
            };

            var result = await client.PostAsJsonAsync("/api/transaction/Withdraw", newWithdraw);

            result.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
        }

        [Fact()]
        public async Task CreateTransfer_ForValidRequest_Returns201Created()
        {
            var client = _factory.CreateClient();
            var newAccount = new
            {
                Amount = 100.0m,
                ToAccountId = 2,
                FromAccountId = 3
            };

            var result = await client.PostAsJsonAsync("/api/transaction/Transfer", newAccount);

            result.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
        }
    }
}