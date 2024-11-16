using Banking.Domain.Entities;

namespace Banking.Domain.Repositories;

public interface IUserRepository
{
    Task<int> Create(User entity);
    Task<User?> GetByIdAsync(int id);
}
