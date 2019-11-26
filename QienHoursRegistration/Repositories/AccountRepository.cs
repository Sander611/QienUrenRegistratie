using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QienHoursRegistration.Repositories;
using Shared;
using Shared.Models;

namespace QienHoursRegistration.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UrenProjectQienContext repositoryContext;
        public AccountRepository(UrenProjectQienContext context)
        {
            this.repositoryContext = context;
        }

        public async Task<List<AccountModel>> GetAllAccounts(string searchString)
        {
            var allAccounts = new List<AccountModel>();
            foreach (var account in await repositoryContext.Accounts.Where(
                                                                            x=>x.FirstName.Contains(searchString) || x.LastName.Contains(searchString) || searchString == null
                                                                          ).ToListAsync())

                allAccounts.Add(new AccountModel
                {
                    AccountId = account.AccountId,
                    FirstName = account.FirstName,
                    LastName = account.LastName,
                    Email = account.Email,
                    DateOfBirth = account.DateOfBirth,
                    HashedPassword = account.HashedPassword,
                    Address = account.Address,
                    ZIP = account.ZIP,
                    MobilePhone = account.MobilePhone,
                    City = account.City,
                    IBAN = account.IBAN,
                    CreationDate = account.CreationDate,
                    ProfileImage = account.ProfileImage,
                    IsAdmin = account.IsAdmin,
                    IsActive = account.IsActive,
                    IsQienEmployee = account.IsQienEmployee,
                    IsSeniorDeveloper = account.IsSeniorDeveloper,
                    IsTrainee = account.IsTrainee
                }) ;

            return allAccounts;
        }

        public async Task<AccountModel> AddNewAccount(AccountModel account)
        {
            Account accountEntity = new Account
            {
                FirstName = account.FirstName,
                LastName = account.LastName,
                Email = account.Email,
                DateOfBirth = account.DateOfBirth,
                HashedPassword = account.HashedPassword,
                Address = account.Address,
                ZIP = account.ZIP,
                MobilePhone = account.MobilePhone,
                City = account.City,
                IBAN = account.IBAN,
                CreationDate = DateTime.Now,
                ProfileImage = account.ProfileImage,
                IsAdmin = account.IsAdmin,
                IsActive = account.IsActive,
                IsQienEmployee = account.IsQienEmployee,
                IsSeniorDeveloper = account.IsSeniorDeveloper,
                IsTrainee = account.IsTrainee
            };

            repositoryContext.Accounts.Add(accountEntity);


            await repositoryContext.SaveChangesAsync();

            return account;


        }

        public string RemoveAccount(int accountId)
        {
            var account = repositoryContext.Accounts.SingleOrDefault(p => p.AccountId == accountId);
            repositoryContext.Accounts.Remove(account);
            repositoryContext.SaveChanges();
            return "Record has succesfully Deleted";

        }

        public async Task<AccountModel> ModifyAccountActivity(int accountId, bool IsActive)
        {
            var account = await repositoryContext.Accounts.SingleOrDefaultAsync(p => p.AccountId == accountId);

            account.IsActive = IsActive;

            await repositoryContext.SaveChangesAsync();

            return new AccountModel
            {
                AccountId = account.AccountId,
                FirstName = account.FirstName,
                LastName = account.LastName,
                Email = account.Email,
                DateOfBirth = account.DateOfBirth,
                HashedPassword = account.HashedPassword,
                Address = account.Address,
                ZIP = account.ZIP,
                MobilePhone = account.MobilePhone,
                City = account.City,
                IBAN = account.IBAN,
                CreationDate = account.CreationDate,
                ProfileImage = account.ProfileImage,
                IsAdmin = account.IsAdmin,
                IsActive = account.IsActive,
                IsQienEmployee = account.IsQienEmployee,
                IsSeniorDeveloper = account.IsSeniorDeveloper,
                IsTrainee = account.IsTrainee
            };

        }

        public async Task<AccountModel> GetOneAccount(int accountId)
        {
            Account account = await repositoryContext.Accounts.SingleAsync(p => p.AccountId == accountId);

            return new AccountModel
            {
                AccountId = account.AccountId,
                FirstName = account.FirstName,
                LastName = account.LastName,
                Email = account.Email,
                DateOfBirth = account.DateOfBirth,
                HashedPassword = account.HashedPassword,
                Address = account.Address,
                ZIP = account.ZIP,
                MobilePhone = account.MobilePhone,
                City = account.City,
                IBAN = account.IBAN,
                CreationDate = account.CreationDate,
                ProfileImage = account.ProfileImage,
                IsAdmin = account.IsAdmin,
                IsActive = account.IsActive,
                IsQienEmployee = account.IsQienEmployee,
                IsSeniorDeveloper = account.IsSeniorDeveloper,
                IsTrainee = account.IsTrainee
            };
        }

        public async Task<AccountModel> UpdateAccount(AccountModel account)
        {
            Account entity = repositoryContext.Accounts.Single(p => p.AccountId == account.AccountId);
            entity.FirstName = account.FirstName;
            entity.LastName = account.LastName;
            entity.Address = account.Address;
            entity.City = account.City;
            entity.CreationDate = account.CreationDate;
            entity.DateOfBirth = account.DateOfBirth;
            entity.Email = account.Email;
            entity.IBAN = account.IBAN;
            entity.ProfileImage = account.ProfileImage;
            entity.ZIP = account.ZIP;
            entity.IsActive = account.IsActive;
            entity.IsAdmin = account.IsAdmin;
            entity.IsQienEmployee = account.IsQienEmployee;
            entity.IsSeniorDeveloper = account.IsSeniorDeveloper;
            entity.MobilePhone = account.MobilePhone;
            entity.IsTrainee = account.IsTrainee;

            await repositoryContext.SaveChangesAsync();

            return account;
        }


        public async Task<List<EmployeeDashboardModel>> getPersonaliaFromAccount(int accountId)
        {
            var personaliaEnitities = await repositoryContext.Accounts.Where(p => p.AccountId == accountId).ToListAsync();
            List<EmployeeDashboardModel> PersonaliaPerUser = new List<EmployeeDashboardModel>();

            foreach (var personalia in personaliaEnitities)
            {
                PersonaliaPerUser.Add(new EmployeeDashboardModel
                {
                    accountId = personalia.AccountId,
                    FirstName = personalia.FirstName,
                    LastName = personalia.LastName,
                    Address = personalia.Address,
                    ZIP = personalia.ZIP,
                    City = personalia.City

                });
            }
            return PersonaliaPerUser;
        }
    }
}
