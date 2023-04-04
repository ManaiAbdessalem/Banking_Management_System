using AutoMapper;
using BankingManagement_Domain.AccountAggreagate;
using BankingManagement_Domain.TransactionAggregate;
using BankingManagement_Service.AccountAggreagate;

namespace BankingManagement_API;

/// <summary>
/// AccountProfile.
/// </summary>
public class AccountProfile : Profile
{
    /// <summary>
    /// Constructor of AccountProfile
    /// </summary>
    public AccountProfile()
    {
        CreateMap<Account, AccountDTO>().ReverseMap();
        CreateMap<Transaction, TransactionDTO>().ReverseMap();
    }
}