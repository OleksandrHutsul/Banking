using AutoMapper;
using Banking.Application.Users.Commands.CreateUser;
using Banking.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace Banking.Application.Users.Commands.Dtos.Tests;

public class UserProfileTests
{
    private IMapper _mapper;

    public UserProfileTests()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<UserProfile>();
        });

        _mapper = configuration.CreateMapper();
    }

    [Fact()]
    public void CreateMap_ForUserToUserDto_MapsCorrectly()
    {
        var user = new User
        {
            Id = 1,
            Name = "Test",
            LastName = "Test",
            Birthday = DateTime.Now,
            Phone = "+380000000000"
        };

        var userDto = _mapper.Map<UserDto>(user);

        userDto.Should().NotBeNull();
        userDto.Id.Should().Be(user.Id);
        userDto.Name.Should().Be(user.Name);
        userDto.LastName.Should().Be(user.LastName);
        userDto.Birthday.Should().Be(user.Birthday);
        userDto.Phone.Should().Be(user.Phone);
    }

    [Fact()]
    public void CreateMap_ForCreateUserCommandToUser_MapsCorrectly()
    {
        var command = new CreateUserCommand
        {
            Id = 1,
            Name = "Test",
            LastName = "Test",
            Birthday = DateTime.Now,
            Phone = "+380000000000"
        };

        var user = _mapper.Map<User>(command);

        user.Should().NotBeNull();
        user.Id.Should().Be(command.Id);
        user.Name.Should().Be(command.Name);
        user.LastName.Should().Be(command.LastName);
        user.Birthday.Should().Be(command.Birthday);
        user.Phone.Should().Be(command.Phone);
    }
}