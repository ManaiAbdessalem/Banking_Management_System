using BankingManagement_Domain.TransactionAggregate;

namespace BankingManagement_Domain.AccountAggreagate;

/// <summary>
/// Interface <see cref="ITransactionRepository"/> containing CRUD.
/// </summary>
public interface ITransactionRepository
{
    /// <summary>
    /// Creates a Transaction.
    /// </summary>
    /// <param name="transaction">transaction</param>
    /// <returns>transaction</returns>
    Task<Transaction> CreateTransaction(Transaction transaction);

    /// <summary>
    /// Get Transactions By AccountId.
    /// </summary>
    /// <param name="accountId">accountId</param>
    /// <returns>List<transaction></transaction></returns>
    Task<List<Transaction>> GetTransactionsByAccountId(int accountId);
}