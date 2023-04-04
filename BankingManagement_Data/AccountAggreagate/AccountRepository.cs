using BankingManagement_Domain.AccountAggreagate;
using Microsoft.EntityFrameworkCore;

namespace BankingManagement_Data.AccountAggreagate;

/// <summary>
/// Class <see cref="AccountRepository"/> containing CRUD.
/// </summary>
public class AccountRepository : IAccountRepository
{
    private BankingManagementContext _bankingManagementContext { get; set; }

    /// <summary>
    /// Constructor of AccountRepository.
    /// </summary>
    /// <param name="bankingManagementContext"></param>
    public AccountRepository(BankingManagementContext bankingManagementContext)
    {
        _bankingManagementContext = bankingManagementContext;
    }

    /// <inheritdoc />
    public async Task UpdateAccount(Account account)
    {
        _bankingManagementContext.Entry(account).State = EntityState.Modified;
         await _bankingManagementContext.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task<Account> GetAccountByRib(string rib)
    {
        return await _bankingManagementContext.Accounts.FirstOrDefaultAsync(x => x.RIB == rib);
    }
}