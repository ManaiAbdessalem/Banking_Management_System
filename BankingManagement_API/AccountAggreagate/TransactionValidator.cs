using FluentValidation;

namespace BankingManagement_API;

/// <summary>
/// TransactionRequest Validator.
/// </summary>
public class TransactionValidator : AbstractValidator<TransactionRequest>
{
    /// <summary>
    /// Constructor of TransactionValidator.
    /// </summary>
    public TransactionValidator()
    {
        RuleFor(x => x.Rib).NotEmpty();
        RuleFor(x => x.Ammount).GreaterThan(0);
    }
}