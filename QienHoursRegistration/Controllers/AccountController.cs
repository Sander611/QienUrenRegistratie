using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QienHoursRegistration.Models;
using QienHoursRegistration.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace QienHoursRegistration.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public async Task<List<Account>> Index()
        {
            var accounts = accountRepository.GetAllAccounts();
            return await accounts;
        }

        public async Task<ActionResult<Account>> Details(int id)
        {
            var account = accountRepository.GetOneAccount(id);
            return await account;
        }


        [HttpPost]
        public async Task<ActionResult<Account>> AddAccount(Account account)
        {
            if (!ModelState.IsValid)
                return account;

            return await accountRepository.AddNewAccount(account);
            //return RedirectToAction("Index", new Account { AccountId = account.AccountId });
        }

        public async Task<ActionResult<Account>> Update(int id)
        {
            //var account = accountRepository.GetOneAccount(id);
            return await accountRepository.GetOneAccount(id);
        }
    }
}