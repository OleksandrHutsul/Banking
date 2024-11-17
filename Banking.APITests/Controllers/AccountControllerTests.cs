using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;
using Xunit;
using System.Net.Http.Json;

namespace Banking.API.Controllers.Tests;

public class AccountControllerTests: IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public AccountControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact()]
    public async Task GetAll_ForValidRequst_Returns200Ok()
    {
        var client = _factory.CreateClient();

        var result = await client.GetAsync("/api/account/GetAll");

        result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }

    [Fact()]
    public async Task GetById_ForValidRequst_Returns200Ok()
    {
        var client = _factory.CreateClient();
        var validId = 1; 

        var result = await client.GetAsync($"/api/account/GetById/{validId}");

        result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }

    [Fact()]
    public async Task GetDetailByCardNumber_ForValidRequst_Returns200Ok()
    {
        var client = _factory.CreateClient();
        var validCardNumber = "1234 1234 1234 1234";

        var result = await client.GetAsync($"/api/account/GetDetailByCardNumber/{validCardNumber}");

        result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }

    [Fact()]
    public async Task Delete_ForValidRequst_Returns404NotFound()
    {
        var client = _factory.CreateClient();
        var deleteId = "8";

        var result = await client.DeleteAsync($"/api/account/Delete/{deleteId}");

        result.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
    }

    [Fact()]
    public async Task Create_ForValidRequest_Returns201Created()
    {
        var client = _factory.CreateClient();
        var newAccount = new
        {
            UserId = 2
        };

        var result = await client.PostAsJsonAsync("/api/account/Create", newAccount);

        result.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
    }
}