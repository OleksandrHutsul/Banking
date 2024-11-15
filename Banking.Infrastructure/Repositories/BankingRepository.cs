using Banking.Domain.Repositories;
using Banking.Infrastructure.Persistence;

namespace Banking.Infrastructure.Repositories;

public class BankingRepository(BankingDbContext dbContext): IBankingRepository
{

}
