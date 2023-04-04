using BankingManagement_Domain.TransactionAggregate;

namespace BankingManagement_Service.AccountAggreagate;

/// <summary>
/// Interface <see cref="IAccountService"/> containing Account services.
/// </summary>
public interface IAccountService
{
    /// <summary>
    /// Updates an Account.
    /// </summary>
    /// <param name="accountToUpdateRib">accountToUpdateRib</param>
    /// <param name="ammount">ammount</param>
    /// <param name="operationType">operationType</param>
    Task UpdateAccount(string accountToUpdateRib, double ammount, OperationType operationType);

    /// <summary>
    /// Get Account by RIB.
    /// </summary>
    /// <param name="rib">rib</param>
    /// <returns>AccountDTO</returns>
    Task<AccountDTO> GetAccountByRib(string rib);

    /// <summary>
    /// Get Account History.
    /// </summary>
    /// <param name="rib">rib</param>
    /// <returns>AccountDTO</returns>
    Task<AccountDTO> GetAccountHistory(string rib);
}