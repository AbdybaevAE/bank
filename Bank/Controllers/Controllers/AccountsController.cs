using Bank.Controllers.DTO;
using Bank.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers
{
    [ApiController]
    [Route("accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountsController(IAccountService accountService)
        {
            this._accountService = accountService;
        }
        [HttpPost]
        public ActionResult<int> CreateAccount([FromBody] CreateAccountRequestBody requestBody)
        {
            Console.WriteLine(requestBody.ToString());
            return 1;
        }
    }
}
