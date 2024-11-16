using AutoMapper;
using Banking.Application.Accounts.Commands.Queries.GetByIdAccount;
using Banking.Application.Users.Commands.Dtos;
using Banking.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Banking.Application.Users.Commands.Queries.GetUserById;

public class GetUserByIdQueryHandler(ILogger<GetByIdAccountQueryHandler> logger,
    IMapper mapper,
    IUserRepository userRepository) : IRequestHandler<GetUserByIdQuery, UserDto?>
{
    public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting user {request.Id}");
        var user = await userRepository.GetByIdAsync(request.Id);

        var userDto = mapper.Map<UserDto?>(user);

        return userDto;
    }
}
