using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared;
using QienHoursRegistration.Repositories;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace QienHoursRegistration.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountRepository accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        [HttpGet("accounts")]
        public async Task<List<AccountModel>> GetAllAccounts(string searchString)
        {
            List<AccountModel> accounts = await accountRepository.GetAllAccounts(searchString);
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
        public async Task<ActionResult<AccountModel>> UpdateAccount(AccountModel account)
        {
            var existingAccount = await accountRepository.GetOneAccount(account.AccountId);
            if (existingAccount == null)
            {
                return BadRequest();
            }
            return await accountRepository.UpdateAccount(account);
        }

        [HttpDelete("deleteAccount/{id}")]
        public void DeleteAccount(int id)
        {
            string succesfull = accountRepository.RemoveAccount(id);
            Console.WriteLine(succesfull);
        }

        [HttpGet("PersonaliaFromUser")]
        public async Task<IEnumerable<AccountModel>> getPersonaliaFromAccount(int accountId)
        {
            return await accountRepository.getPersonaliaFromAccount(accountId);
        }
    }
}