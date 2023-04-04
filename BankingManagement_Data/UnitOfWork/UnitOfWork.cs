using BankingManagement_Data.AccountAggreagate;
using BankingManagement_Data.TransactionAggregate;
using BankingManagement_Domain.AccountAggreagate;
using Microsoft.Extensions.Logging;

namespace BankingManagement_Data;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly BankingManagementContext _context;

    public IAccountRepository Accounts { get; private set; }

    public ITransactionRepository Transactions { get; private set; }

    public UnitOfWork(BankingManagementContext context, ILoggerFactory loggerFactory)
    {
        _context = context;

        Accounts = new AccountRepository(context);
        Transactions = new TransactionRepository(context);
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}