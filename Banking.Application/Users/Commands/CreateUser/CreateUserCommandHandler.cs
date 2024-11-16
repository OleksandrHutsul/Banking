using AutoMapper;
using Banking.Domain.Entities;
using Banking.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Banking.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler(ILogger<CreateUserCommandHandler> logger, 
    IMapper mapper,
    IUserRepository userRepository) : IRequestHandler<CreateUserCommand, int>
{
    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating a new user");

        var user = mapper.Map<User>(request);

        int id = await userRepository.Create(user);

        return id;
    }
}
