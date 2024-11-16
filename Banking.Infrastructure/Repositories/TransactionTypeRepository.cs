using Banking.Domain.Entities;
using Banking.Domain.Repositories;
using Banking.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Banking.Infrastructure.Repositories;

public class TransactionTypeRepository(BankingDbContext dbContext) : ITransactionTypeRepository
{
    public async Task<int> Create(TransactionType entity)
    {
        dbContext.TransactionTypes.Add(entity);
        await dbContext.SaveChangesAsync();

        return entity.Id;
    }

    public async Task Delete(TransactionType entity)
    {
        dbContext.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<TransactionType>> GetAllAsync()
    {
        var transactionTypes = await dbContext.TransactionTypes
            .ToListAsync();

        return transactionTypes;
    }

    public async Task<TransactionType?> GetByIdAsync(int id)
    {
        var transactionTypes = await dbContext.TransactionTypes
            .FirstOrDefaultAsync(x => x.Id == id);

        return transactionTypes;
    }

    public async Task<int> Update(TransactionType entity)
    {
        var existingEntity = await dbContext.TransactionTypes.FindAsync(entity.Id);

        if (existingEntity == null)
        {
            throw new KeyNotFoundException($"TransactionType with ID {entity.Id} not found.");
        }

        dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);

        await dbContext.SaveChangesAsync();

        return existingEntity.Id;
    }
}