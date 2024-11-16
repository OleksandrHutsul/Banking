using Banking.Domain.Entities;

namespace Banking.Domain.Repositories;

public interface ITransactionTypeRepository
{
    Task<IEnumerable<TransactionType>> GetAllAsync();
    Task<TransactionType?> GetByIdAsync(int id);
    Task<int> Create(TransactionType entity);
    Task<int> Update(TransactionType entity);
    Task Delete(TransactionType entity);
}
