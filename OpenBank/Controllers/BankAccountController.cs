using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenBank.Request;
using OpenBank.Services;

namespace OpenBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private readonly IBankAccountService bankAccountService;

        public BankAccountController(IBankAccountService bankAccountService)
        {
            this.bankAccountService = bankAccountService;
        }

        [HttpGet]
        public IActionResult GetBankAccountBalance(int accountId)
        {
            if (accountId>0)
            {
                var result = this.bankAccountService.GetBankAccountBalance(accountId);
                if (result.IsSuccess)
                {
                    return Ok(result.Value);
                }
                return BadRequest(result.Error);
            }
            return BadRequest("Invalid Bank Account");
        }

        [HttpPost]
        public IActionResult CreatebankAccount(CreateBankAccountRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = this.bankAccountService.CreateAccount(request);
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
