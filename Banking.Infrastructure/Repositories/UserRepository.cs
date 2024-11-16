using Banking.Domain.Entities;
using Banking.Domain.Repositories;
using Banking.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Banking.Infrastructure.Repositories;

public class UserRepository(BankingDbContext dbContext) : IUserRepository
{
    public async Task<int> Create(User entity)
    {
        dbContext.Users.Add(entity);
        await dbContext.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        var users = await dbContext.Users
            .Include(x => x.Accounts)
            .FirstOrDefaultAsync(x => x.Id == id);

        return users;
    }
}
