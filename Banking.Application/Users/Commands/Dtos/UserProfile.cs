using AutoMapper;
using Banking.Application.Users.Commands.CreateUser;
using Banking.Domain.Entities;

namespace Banking.Application.Users.Commands.Dtos;

public class UserProfile: Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserCommand, User>();
        CreateMap<User, UserDto>();
    }
}
