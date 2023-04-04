using BankingManagement_Domain.AccountAggreagate;

namespace BankingManagement_Domain.TransactionAggregate;

/// <summary>
/// The <see cref="Transaction"/> class.
/// </summary>
public class Transaction
{
    /// <summary>
    /// Transaction Id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Transaction operation type.
    /// </summary>
    public OperationType OperationType { get; set; }

    /// <summary>
    /// Creation date of the transaction.
    /// </summary>
    public DateTime CreationDate { get; set; }

    /// <summary>
    /// Ammount of the transaction.
    /// </summary>
    public double Ammount { get; set; }

    /// <summary>
    /// Account of the transaction.
    /// </summary>
    public Account Account { get; set; }
}