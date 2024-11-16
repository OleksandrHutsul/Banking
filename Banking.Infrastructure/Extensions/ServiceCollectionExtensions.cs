using Banking.Domain.Repositories;
using Banking.Infrastructure.Persistence;
using Banking.Infrastructure.Repositories;
using Banking.Infrastructure.Seeder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Banking.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("BankingDb");
        services.AddDbContext<BankingDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<IBankingSeeder, BankingSeeder>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}
