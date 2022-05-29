using Microsoft.AspNetCore.Mvc;
using TestApp.Domain.DTO_s.AccountDTO;
using TestApp.Services.Abstraction;

namespace TestApp.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost("check")]
        public async Task<IActionResult> CheckAccount([FromBody] CheckAccountDTO checkAccountDTO)
        {
           var result = await accountService.CheckAccountAsync(checkAccountDTO);
            return Ok(result);
        }
    }
}
