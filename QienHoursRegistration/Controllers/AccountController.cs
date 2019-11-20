using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QienHoursRegistration.DataContext;
using QienHoursRegistration.Repositories;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

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
        public async Task<List<AccountModel>> GetAllAccounts()
        {
            List<AccountModel> accounts = await accountRepository.GetAllAccounts();
            return accounts;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountModel>> GetOneAccount(int id)
        {
            AccountModel account = await accountRepository.GetOneAccount(id);
            return account;
        }


        [HttpPost("createAccount")]
        public async Task<ActionResult<AccountModel>> AddAccount(AccountModel account)
        {
            if (!ModelState.IsValid)
                return account;

            return await accountRepository.AddNewAccount(account);
        }

        [HttpPost("updateAccount")]
        public async Task<ActionResult<AccountModel>> UpdateAccount(int id, AccountModel account)
        {
            var existingAccount = await accountRepository.GetOneAccount(id);
            if (existingAccount == null)
            {
                return BadRequest();
            }
            return await accountRepository.UpdateAccount(account);
        }
    }
}