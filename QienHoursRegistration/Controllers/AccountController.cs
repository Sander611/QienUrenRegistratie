using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QienHoursRegistration.DataContext;
using QienHoursRegistration.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace QienHoursRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountRepository accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        [HttpGet("accounts")]
        public async Task<List<Account>> GetAllAccounts()
        {
            var accounts = await accountRepository.GetAllAccounts();
            return accounts;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetOneAccount(int id)
        {
            var account = accountRepository.GetOneAccount(id);
            return await account;
        }


        [HttpPost("createAccount")]
        public async Task<ActionResult<Account>> AddAccount(Account account)
        {
            if (!ModelState.IsValid)
                return account;

            return await accountRepository.AddNewAccount(account);
            //return RedirectToAction("Index", new Account { AccountId = account.AccountId });
        }

        [HttpPost("updateAccount")]
        public async Task<ActionResult<Account>> UpdateAccount(Account account)
        {
            //var account = accountRepository.GetOneAccount(id);
            return await accountRepository.UpdateAccount(account);
        }
    }
}