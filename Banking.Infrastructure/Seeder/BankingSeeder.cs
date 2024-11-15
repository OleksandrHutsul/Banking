using Banking.Domain.Entities;
using Banking.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Banking.Infrastructure.Seeder;

public class BankingSeeder(BankingDbContext dbContext): IBankingSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            await SeedDataAsync(GetTransactionTypes(), dbContext.TransactionTypes);
            await SeedDataAsync(GetUsers(), dbContext.Users);
            await SeedDataAsync(GetAccounts(), dbContext.Accounts);
            await SeedDataAsync(GetTransactions(), dbContext.Transactions);
        }
    }

    private async Task SeedDataAsync<T>(IEnumerable<T> data, DbSet<T> dbSet) where T : class
    {
        if (!dbSet.Any())
        {
            dbSet.AddRange(data);
            await dbContext.SaveChangesAsync();
        }
    }

    private IEnumerable<TransactionType> GetTransactionTypes()
    {
        List<TransactionType> transactionTypes = [
            new()
                {
                    Name = "Deposit"
                },
                new TransactionType()
                {
                    Name = "Transfer",
                },
                new TransactionType()
                {
                    Name = "Withdraw",
                }
            ];
        return transactionTypes;
    }

    private IEnumerable<User> GetUsers()
    {
        List<User> users = [
            new()
                {
                    Name = "Oleksandr",
                    LastName = "Hutsul",
                    Birthday = new DateTime(2003, 03, 11),
                    Phone = "+380977600280"
                },
                new User()
                {
                    Name = "Jon",
                    LastName = "Doyl",
                    Birthday = new DateTime(1990, 11, 01),
                    Phone = "+380997155779"
                },
                new User()
                {
                    Name = "Jerry",
                    LastName = "McCarter",
                    Birthday = new DateTime(1970, 06, 30),
                    Phone = "+380977600280"
                }
            ];
        return users;
    }

    private IEnumerable<Account> GetAccounts()
    {
        List<Account> accounts = [
            new()
                {
                    Balance = 30000,
                    CreatedDate = new DateTime(2023, 07, 07),
                    UserId = 1,
                    CardNumber = "4321 4321 4321 4321"
                },
                new Account()
                {
                    Balance = 50000,
                    CreatedDate = new DateTime(2023, 09, 17),
                    UserId = 2,
                    CardNumber = "1234 1234 1234 1234"
                },
                new Account()
                {
                    Balance = 130000,
                    CreatedDate = new DateTime(2023, 01, 01),
                    UserId = 3,
                    CardNumber = "5678 5678 5678 5678"
                }
            ];
        return accounts;
    }

    private IEnumerable<Transaction> GetTransactions()
    {
        List<Transaction> transactions = [
            new()
                {
                    Amount = 10000,
                    TransactionDate = new DateTime(2024, 11, 11),
                    TransactionTypeId = 1,
                    ToAccountId = 1
                },
                new Transaction()
                {
                    Amount = 10000,
                    TransactionDate = new DateTime(2024, 11, 15),
                    TransactionTypeId = 2,
                    FromAccountId = 2,
                    ToAccountId = 1
                },
                new Transaction()
                {
                    Amount = 33000,
                    TransactionDate = DateTime.UtcNow,
                    TransactionTypeId = 3,
                    ToAccountId = 3
                }
            ];
        return transactions;
    }
}