using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingManagement_Service.AccountAggreagate;

/// <summary>
/// class <see cref="AccountDTO"/>
/// </summary>
public class AccountDTO
{
    /// <summary>
    /// Account Id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// RIB.
    /// </summary>
    public string RIB { get; set; }

    /// <summary>
    /// First Name of Beneficiary.
    /// </summary>
    public string FirstNameBeneficiary { get; set; }

    /// <summary>
    /// Last name of Beneficiary.
    /// </summary>
    public string LastNameBeneficiary { get; set; }

    /// <summary>
    /// Balance of account.
    /// </summary>
    public double Balance { get; set; }

    /// <summary>
    /// Update date.
    /// </summary>
    public DateTime? UpdateDate { get; set; }

    /// <summary>
    /// List of transactions of the account.
    /// </summary>
    public IList<TransactionDTO> Transactions { get; set; }
}