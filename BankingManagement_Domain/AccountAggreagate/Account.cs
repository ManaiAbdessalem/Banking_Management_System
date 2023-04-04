using BankingManagement_Domain.TransactionAggregate;

namespace BankingManagement_Domain.AccountAggreagate;

/// <summary>
/// class <see cref="Account"/>
/// </summary>
public class Account
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
    public IList<Transaction> Transactions { get; set; }
}