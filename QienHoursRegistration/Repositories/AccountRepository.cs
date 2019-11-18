using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QienHoursRegistration.Models;
using QienHoursRegistration.DataContext;



namespace QienHoursRegistration.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly RepositoryContext repositoryContext;
        public AccountRepository(RepositoryContext context)
        {
            this.repositoryContext = context;
        }

        public List<Account> GetAllAccounts()
        {
            var All_Accounts = repositoryContext.Accounts.Select(p => new Account
            {
                AccountId = p.AccountId,
                Name = p.Name,
                Email = p.Email,
                DateOfBirth = p.DateOfBirth,
                HashedPassword = p.HashedPassword,
                Address = p.Address,
                ZIP = p.ZIP,
                MobilePhone = p.MobilePhone,
                City = p.City,
                IBAN = p.IBAN,
                CreationDate = p.CreationDate,
                ProfileImage = p.ProfileImage,
                IsAdmin = p.IsAdmin,
                IsActive = p.IsActive,
                IsQienEmployee = p.IsQienEmployee,
                IsSeniorDeveloper = p.IsSeniorDeveloper,
                IsTrainee = p.IsTrainee

            }).ToList();

            return All_Accounts;
        }

        public void AddNewAccount(Account account)
        {
            repositoryContext.Accounts.Add(new Account
            {
                AccountId = account.AccountId,
                Name = account.Name,
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
            });

            repositoryContext.SaveChanges();
        }

        public void RemoveAccount(int accountId)
        {
            var account = repositoryContext.Accounts.SingleOrDefault(p => p.AccountId == accountId);
            repositoryContext.Accounts.Remove(account);
            repositoryContext.SaveChanges();
        }

        public void ModifyAccountActivity(int accountId, bool IsActive)
        {
            var account = repositoryContext.Accounts.SingleOrDefault(p => p.AccountId == accountId);
            account.IsActive = IsActive;

        }

        public Account GetOneAccount(int accountId)
        {
            var account = repositoryContext.Accounts.Single(p => p.AccountId == accountId);
            return new Account
            {
                AccountId = account.AccountId,
                Name = account.Name,
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

        public void UpdateAccount(Account account)
        {
            var entity = repositoryContext.Accounts.Single(p => p.AccountId == account.AccountId);
            entity.Name = account.Name;
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

            repositoryContext.SaveChanges();
        }
    }
}
