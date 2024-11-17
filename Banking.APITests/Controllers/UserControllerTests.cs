using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using Xunit;

namespace Banking.API.Controllers.Tests;

public class UserControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public UserControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact()]
    public async Task GetById_ForValidRequst_Returns200Ok()
    {
        var client = _factory.CreateClient();
        var validId = 1;

        var result = await client.GetAsync($"/api/user/GetById/{validId}");

        result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }

    [Fact()]
    public async Task CreateUser_ForValidRequest_Returns201Created()
    {
        var client = _factory.CreateClient();
        var newAccount = new
        {
            Name = "test",
            LastName = "test",
            Birthday = new DateTime(2000, 10,10),
            Phone = "0000000000"
        };

        var result = await client.PostAsJsonAsync("/api/user/Create", newAccount);

        result.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
    }
}