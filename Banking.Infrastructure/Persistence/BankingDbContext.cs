using Banking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Banking.Infrastructure.Persistence;

public class BankingDbContext(DbContextOptions<BankingDbContext> options) : DbContext(options)
{
    internal DbSet<Account> Accounts { get; set; }
    internal DbSet<Transaction> Transactions { get; set; }
    internal DbSet<TransactionType> TransactionTypes { get; set; }
    internal DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.FromAccount) 
            .WithMany()                 
            .HasForeignKey(t => t.FromAccountId) 
            .OnDelete(DeleteBehavior.Restrict);  

        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.ToAccount)   
            .WithMany(a => a.Transactions) 
            .HasForeignKey(t => t.ToAccountId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Account>()
            .HasOne(a => a.User)
            .WithMany(u => u.Accounts)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.TransactionType)
            .WithMany()
            .HasForeignKey(t => t.TransactionTypeId)
            .OnDelete(DeleteBehavior.Cascade);
    }

}
