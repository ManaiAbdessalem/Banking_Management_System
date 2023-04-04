using BankingManagement_Domain.AccountAggreagate;

namespace BankingManagement_Data;

public interface IUnitOfWork
{
    IAccountRepository Accounts { get; }
    ITransactionRepository Transactions { get; }

    Task CompleteAsync();
}