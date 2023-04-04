namespace BankingManagement_Domain.AccountAggreagate;

/// <summary>
/// Interface <see cref="IAccountRepository"/> containing CRUD.
/// </summary>
public interface IAccountRepository
{
    /// <summary>
    /// Updates an Account.
    /// </summary>
    /// <param name="account"></param>
    Task UpdateAccount(Account account);

    /// <summary>
    /// Get Account by rib.
    /// </summary>
    /// <param name="rib">rib</param>
    /// <returns>Account</returns>
    Task<Account> GetAccountByRib(string rib);
}