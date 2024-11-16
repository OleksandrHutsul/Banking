using Banking.Domain.Entities;
using Banking.Domain.Repositories;
using Banking.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Banking.Infrastructure.Repositories;

public class AccountRepository(BankingDbContext dbContext): IAccountRepository
{
    public async Task<int> Create(Account entity)
    {
        dbContext.Accounts.Add(entity);
        await dbContext.SaveChangesAsync();

        return entity.Id;
    }

    public async Task Delete(Account entity)
    {
        dbContext.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Account>> GetAllAsync()
    {
        var accounts = await dbContext.Accounts
            .Include(r => r.User)
            .Include(r => r.Transactions)
            .ToListAsync();

        return accounts;
    }

    public async Task<Account?> GetByIdAsync(int id)
    {
        var accounts = await dbContext.Accounts
            .Include(r => r.User)
            .Include(r => r.Transactions)
            .FirstOrDefaultAsync(x => x.Id == id);

        return accounts;
    }

    public async Task<bool> IsCardNumberUniqueAsync(string cardNumber)
    {
        return !await dbContext.Accounts.AnyAsync(a => a.CardNumber == cardNumber);
    }
}
