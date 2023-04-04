using BankingManagement_Domain.AccountAggreagate;
using BankingManagement_Domain.TransactionAggregate;
using Microsoft.EntityFrameworkCore;

namespace BankingManagement_Data.TransactionAggregate;

/// <summary>
/// Class <see cref="TransactionRepository"/> containing CRUD.
/// </summary>
public class TransactionRepository : ITransactionRepository
{
    private BankingManagementContext _bankingManagementContext { get; set; }

    /// <summary>
    /// Constructor of TransactiontRepository.
    /// </summary>
    /// <param name="bankingManagementContext"></param>
    public TransactionRepository(BankingManagementContext bankingManagementContext)
    {
        _bankingManagementContext = bankingManagementContext;
    }

    /// <inheritdoc />
    public async Task<Transaction> CreateTransaction(Transaction transaction)
    {
        await _bankingManagementContext.AddAsync<Transaction>(transaction);
        await _bankingManagementContext.SaveChangesAsync();
        return transaction;
    }

    /// <inheritdoc />
    public async Task<List<Transaction>> GetTransactionsByAccountId(int accountId)
    {
        return await _bankingManagementContext.Transactions.Where(x => x.Account.Id == accountId).ToListAsync();
    }
}