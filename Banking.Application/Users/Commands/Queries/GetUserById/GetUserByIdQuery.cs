using Banking.Application.Users.Commands.Dtos;
using MediatR;

namespace Banking.Application.Users.Commands.Queries.GetUserById;

public class GetUserByIdQuery(int id) : IRequest<UserDto?>
{
    public int Id { get; set; } = id;
}
