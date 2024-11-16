using Banking.Domain.Entities;

namespace Banking.Domain.Repositories;

public interface IAccountRepository
{
    Task<IEnumerable<Account>> GetAllAsync();
    Task<Account?> GetByIdAsync(int id);
    Task<int> Create(Account entity);
    Task Delete(Account entity);
    Task<bool> IsCardNumberUniqueAsync(string cardNumber);
}
