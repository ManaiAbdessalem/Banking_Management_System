using BankingManagement_Domain.TransactionAggregate;

namespace BankingManagement_Service.AccountAggreagate
{
    /// <summary>
    /// The <see cref="TransactionDTO"/> class.
    /// </summary>
    public class TransactionDTO
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
    }
}