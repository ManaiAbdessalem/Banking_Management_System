using BankingManagement_Domain.TransactionAggregate;
using BankingManagement_Service.AccountAggreagate;
using Microsoft.AspNetCore.Mvc;

namespace BankingManagement_API.Controllers;

/// <summary>
/// Controller <see cref="AccountController"/> containing Account actions.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private IAccountService _accountService { get; set; }

    /// <summary>
    /// Constructor of AccountController.
    /// </summary>
    /// <param name="accountService">accountService</param>
    /// <param name="mapper">mapper</param>
    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    /// <summary>
    /// Make a deposit in an account.
    /// </summary>
    /// <param name="id">rib of the account</param>
    /// <param name="request">TransactionRequest</param>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPut("deposit/{rib}")]
    public async Task<ActionResult> Deposit(string rib, TransactionRequest request)
    {
        if (rib != request.Rib)
        {
            return BadRequest("Ribs does not match!");
        }

        AccountDTO accountToUpdate = await _accountService.GetAccountByRib(rib);

        if (accountToUpdate is null)
        {
            return NotFound("Account to update does not exists!");
        }

        await _accountService.UpdateAccount(accountToUpdate.RIB, request.Ammount, OperationType.debit);
        return NoContent();
    }

    /// <summary>
    /// Retrieve some or all of an account's savings.
    /// </summary>
    /// <param name="id">rib of Account</param>
    /// <param name="request">TransactionRequest</param>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPut("credit/{rib}")]
    public async Task<ActionResult> Credit(string rib, TransactionRequest request)
    {
        if (rib != request.Rib)
        {
            return BadRequest("Ribs does not match!");
        }

        AccountDTO accountToUpdateDto = await _accountService.GetAccountByRib(rib);

        if (accountToUpdateDto is null)
        {
            return NotFound("Account to update does not exists!");
        }

        if (request.Ammount > accountToUpdateDto.Balance)
        {
            return BadRequest("You do not have enough balance to make the withdrawal!");
        }

        await _accountService.UpdateAccount(accountToUpdateDto.RIB, request.Ammount, OperationType.credit);
        return NoContent();
    }

    /// <summary>
    /// Get account history.
    /// </summary>
    /// <param name="rib">rib of account</param>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("history/{rib}")]
    public async Task<ActionResult> GetAccountHistory(string rib)
    {
        if (string.IsNullOrEmpty(rib))
        {
            return BadRequest("Rib is required!");
        }

        AccountDTO accountHistory = await _accountService.GetAccountHistory(rib);

        if (accountHistory is null)
        {
            return NotFound("Account to update does not exists!");
        }

        return new OkObjectResult(accountHistory);
    }
}