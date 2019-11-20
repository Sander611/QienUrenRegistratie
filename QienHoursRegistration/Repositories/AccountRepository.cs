using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QienHoursRegistration.DataContext;
using QienHoursRegistration.Repositories;

namespace QienHoursRegistration.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly RepositoryContext repositoryContext;
        public AccountRepository(RepositoryContext context)
        {
            this.repositoryContext = context;
        }

        public async Task<List<Account>> GetAllAccounts()
        {

            return await repositoryContext.Accounts.ToListAsync();
        }

        public async Task<Account> AddNewAccount(Account account)
        {
            var AccountModel = new Account
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

            repositoryContext.Accounts.Add(AccountModel);


            await repositoryContext.SaveChangesAsync();

            return AccountModel;


        }

        public async Task<Account> RemoveAccount(int accountId)
        {
            var account = repositoryContext.Accounts.SingleOrDefault(p => p.AccountId == accountId);
            repositoryContext.Accounts.Remove(account);
            await repositoryContext.SaveChangesAsync();

            return account;
        }

        public async Task<Account> ModifyAccountActivity(int accountId, bool IsActive)
        {
            var account = await repositoryContext.Accounts.SingleOrDefaultAsync(p => p.AccountId == accountId);

            account.IsActive = IsActive;

            return account;


        }

        public async Task<Account> GetOneAccount(int accountId)
        {
            var account = await repositoryContext.Accounts.SingleAsync(p => p.AccountId == accountId);

            return new Account
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

        public async Task<Account> UpdateAccount(Account account)
        {
            var entity = repositoryContext.Accounts.Single(p => p.AccountId == account.AccountId);
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

            return entity;
        }
    }
}
