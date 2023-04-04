using BankingManagement_Data.AccountAggreagate;
using BankingManagement_Data.TransactionAggregate;
using BankingManagement_Domain.AccountAggreagate;
using BankingManagement_Domain.TransactionAggregate;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection.Emit;

namespace BankingManagement_Data;

public class BankingManagementContext : DbContext
{
    public BankingManagementContext(DbContextOptions<BankingManagementContext> options) : base(options)
    {
    }

    public DbSet<Account> Accounts { get; set; } = null!;
    public DbSet<Transaction> Transactions { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        new AccountEntityTypeConfiguration().Configure(builder.Entity<Account>());
        new TransactionEntityTypeConfiguration().Configure(builder.Entity<Transaction>());
    }
}