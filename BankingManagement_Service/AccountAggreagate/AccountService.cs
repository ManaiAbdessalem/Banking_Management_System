using AutoMapper;
using BankingManagement_Data;
using BankingManagement_Domain.AccountAggreagate;
using BankingManagement_Domain.TransactionAggregate;

namespace BankingManagement_Service.AccountAggreagate;

/// <summary>
/// Class <see cref="AccountService"/> containing Account Services.
/// </summary>
public class AccountService : IAccountService
{
    private readonly IUnitOfWork _unitOfWork;

    private IMapper _mapper { get; set; }

    /// <summary>
    /// Constructor of AccountService.
    /// </summary>
    /// <param name="accountRepository">accountRepository</param>
    public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public async Task UpdateAccount(string accountToUpdateRib, double ammount, OperationType operationType)
    {
        Account accountToUpdate = await _unitOfWork.Accounts.GetAccountByRib(accountToUpdateRib);
        accountToUpdate.UpdateDate = DateTime.Now;
        if (operationType == OperationType.debit)
        {
            accountToUpdate.Balance += ammount;
        }
        else
        {
            accountToUpdate.Balance -= ammount;
        }

        Transaction transaction = new Transaction()
        {
            CreationDate = DateTime.Now,
            OperationType = operationType,
            Ammount = ammount,
            Account = accountToUpdate
        };

        await _unitOfWork.Accounts.UpdateAccount(accountToUpdate);
        await _unitOfWork.Transactions.CreateTransaction(transaction);
        await _unitOfWork.CompleteAsync();
    }

    /// <inheritdoc />
    public async Task<AccountDTO> GetAccountByRib(string rib)
    {
        Account account = await _unitOfWork.Accounts.GetAccountByRib(rib);
        return _mapper.Map<AccountDTO>(account);
    }

    /// <inheritdoc />
    public async Task<AccountDTO> GetAccountHistory(string rib)
    {
        AccountDTO account = await GetAccountByRib(rib);
        if (account == null)
        {
            return null;
        }
        account.Transactions = _mapper.Map<List<TransactionDTO>>(await _unitOfWork.Transactions.GetTransactionsByAccountId(account.Id));

        return account;
    }
}