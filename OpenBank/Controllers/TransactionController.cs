using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenBank.Request;
using OpenBank.Services;

namespace OpenBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }


        [HttpGet]
        public IActionResult GetBankAccountBalance(int accountId)
        {
            if (accountId > 0)
            {
                var result = this.transactionService.GetTransferHistoryByAccountId(accountId);
                if (result.IsSuccess)
                {
                    return Ok(result.Value);
                }
                return BadRequest(result.Error);
            }
            return BadRequest("Invalid Bank Account");
        }

        [HttpPost]
        public IActionResult TransferToAccount(TransferToAccountRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = this.transactionService.TransferToAccount(request);
                if (result.IsSuccess)
                {
                    return Ok();
                }
                return BadRequest(result.Error);
            }
            return BadRequest("Invalid Inputs");
        }
    }
}
