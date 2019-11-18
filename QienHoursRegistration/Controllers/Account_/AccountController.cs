using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QienHoursRegistration.Models;
using QienHoursRegistration.Repositories;
using Microsoft.AspNetCore.Mvc;
using QienHoursRegistration.Repositories.Interfaces;

namespace QienHoursRegistration.Controllers.Account_
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public IActionResult Index()
        {
            var accounts = accountRepository.GetAllAccounts();
            return View(accounts);
        }

        public IActionResult Details(int id)
        {
            var account = accountRepository.GetOneAccount(id);
            return View(account);
        }

        public IActionResult Add()
        {
            return View(new Account());
        }

        [HttpPost]
        public IActionResult AddAccount(Account account)
        {
            if (!ModelState.IsValid)
                return View(account);
            accountRepository.AddNewAccount(account);
            return RedirectToAction("Index", new Account { AccountId = account.AccountId });
        }

        public IActionResult Update(int id)
        {
            var account = accountRepository.GetOneAccount(id);
            return View(account);   
        }
    }
}