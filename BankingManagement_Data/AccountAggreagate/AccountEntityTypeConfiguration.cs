using BankingManagement_Domain.AccountAggreagate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingManagement_Data.AccountAggreagate;

public class AccountEntityTypeConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Account");
        builder.Property(e => e.FirstNameBeneficiary).IsRequired();
        builder.Property(e => e.LastNameBeneficiary).IsRequired();
        builder.Property(e => e.RIB).IsRequired();
        builder.HasMany(c => c.Transactions).WithOne(c => c.Account).IsRequired();
    }
}