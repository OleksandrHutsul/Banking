using Banking.Domain.Entities;
using Banking.Domain.Repositories;
using Banking.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Banking.Infrastructure.Repositories;

public class TransactionRepository(BankingDbContext dbContext) : ITransactionRepository
{
    public async Task<int> Deposit(Transaction entity)
    {
        var account = await dbContext.Accounts.FindAsync(entity.ToAccountId);
        if (account == null)
        {
            throw new InvalidOperationException($"Account with ID {entity.ToAccountId} not found.");
        }

        if (entity.Amount <= 0)
        {
            throw new InvalidOperationException($"The sum cannot be negative or equal to zero.");
        }

        account.Balance += entity.Amount;

        dbContext.Transactions.Add(entity);

        await dbContext.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<IEnumerable<Transaction>> GetAllAsync()
    {
        var transactions = await dbContext.Transactions
            .Include(t => t.ToAccount)
            .Include(t => t.ToAccount.User)
            .Include(t => t.FromAccount)
            .Include(t => t.TransactionType)
            .ToListAsync();

        return transactions;
    }

    public async Task<Transaction?> GetByIdAsync(int id)
    {
        var transaction = await dbContext.Transactions
            .Include(t => t.ToAccount)
            .Include(t => t.ToAccount.User)
            .Include(t => t.FromAccount)
            .Include(t => t.TransactionType)
            .FirstOrDefaultAsync(x => x.Id == id);

        return transaction;
    }

    public async Task<int> Transfer(Transaction entity)
    {
        using var transaction = await dbContext.Database.BeginTransactionAsync();

        try
        {
            var fromAccount = await dbContext.Accounts.FindAsync(entity.FromAccountId);
            if (fromAccount == null)
            {
                throw new InvalidOperationException($"FromAccount with ID {entity.FromAccountId} not found.");
            }

            var toAccount = await dbContext.Accounts.FindAsync(entity.ToAccountId);
            if (toAccount == null)
            {
                throw new InvalidOperationException($"ToAccount with ID {entity.ToAccountId} not found.");
            }

            if (fromAccount.Balance < entity.Amount)
            {
                throw new InvalidOperationException($"Insufficient funds. Balance: {fromAccount.Balance}, Transfer amount: {entity.Amount}");
            }

            if(entity.Amount <= 0)
            {
                throw new InvalidOperationException($"The sum cannot be negative or equal to zero.");
            }

            fromAccount.Balance -= entity.Amount;
            toAccount.Balance += entity.Amount;

            dbContext.Transactions.Add(entity);
            await dbContext.SaveChangesAsync();
            await transaction.CommitAsync();

            return entity.Id;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<int> Withdraw(Transaction entity)
    {
        var account = await dbContext.Accounts.FindAsync(entity.ToAccountId);
        if (account == null)
        {
            throw new InvalidOperationException($"Account with ID {entity.ToAccountId} not found.");
        }

        if (entity.Amount <= 0)
        {
            throw new InvalidOperationException($"The sum cannot be negative or equal to zero.");
        }

        if (account.Balance >= entity.Amount)
        {
            account.Balance -= entity.Amount;
        }
        else
        {
            throw new InvalidOperationException($"The withdrawal amount {entity.Amount} cannot exceed the amount on the balance {account.Balance}");
        }

        dbContext.Transactions.Add(entity);

        await dbContext.SaveChangesAsync();

        return entity.Id;
    }
}
