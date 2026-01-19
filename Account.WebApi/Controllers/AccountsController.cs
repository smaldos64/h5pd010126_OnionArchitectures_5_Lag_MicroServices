using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Account.Application.Interfaces;
using Account.Application.DTO;

namespace Account.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountAppService _service;
        public AccountsController(IAccountAppService service) => _service = service;

        [HttpGet("{id}")] 
        public IActionResult Get(int id) => Ok(_service.GetAccount(id));

        [HttpGet] 
        public IActionResult GetAll() => Ok(_service.GetAllAccounts());

        [HttpPost]
        public IActionResult Create(CreateAccountRequest req)
        {
            _service.CreateAccount(req); 
            return Ok();
        }

        [HttpPost("deposit")]
        public IActionResult Deposit(TransactionRequest req)
        {
            _service.Deposit(req); 
            return Ok();
        }

        [HttpPost("withdraw")]
        public IActionResult Withdraw(TransactionRequest req)
        {
            _service.Withdraw(req); 
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteAccount(id); 
            return NoContent();
        }
    }
}
