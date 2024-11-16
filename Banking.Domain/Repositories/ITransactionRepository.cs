using Banking.Domain.Entities;

namespace Banking.Domain.Repositories;

public interface ITransactionRepository
{
    Task<int> Deposit(Transaction entity);
    Task<int> Withdraw(Transaction entity);
    Task<int> Transfer(Transaction entity);
    Task<IEnumerable<Transaction>> GetAllAsync();
    Task<Transaction?> GetByIdAsync(int id);
}