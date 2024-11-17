using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;

namespace Banking.API.Controllers.Tests;

public class TransactionTypeControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public TransactionTypeControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact()]
    public async Task GetAllTransactionType_ForValidRequst_Returns200Ok()
    {
        var client = _factory.CreateClient();

        var result = await client.GetAsync("/api/TransactionType/GetAll");

        result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }

    [Fact()]
    public async Task GetTransactionTypeById_ForValidRequst_Returns200Ok()
    {
        var client = _factory.CreateClient();
        var validId = 1;

        var result = await client.GetAsync($"/api/TransactionType/GetById/{validId}");

        result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }

    [Fact()]
    public async Task CreateTransactionType_ForValidRequest_Returns201Created()
    {
        var client = _factory.CreateClient();
        var newAccount = new
        {
            Name = "test"
        };

        var result = await client.PostAsJsonAsync("/api/TransactionType/Create", newAccount);

        result.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
    }

    [Fact()]
    public async Task UpdateTransactionType_ForValidRequest_Returns200Ok()
    {
        var client = _factory.CreateClient();
        var validId = 6; 
        var updateTransactionTypeCommand = new
        {
            Name = "Updated Transaction Type"
        };

        var result = await client.PutAsJsonAsync($"/api/transactiontype/Update/{validId}", updateTransactionTypeCommand);

        result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }
}