using System.Collections.Generic;
using QienHoursRegistration.Models;

namespace QienHoursRegistration.Repositories
{
    public interface IAccountRepository
    {
        void AddNewAccount(Account account);
        List<Account> GetAllAccounts();
        Account GetOneAccount(int accountId);
        void ModifyAccountActivity(int accountId, bool IsActive);
        void RemoveAccount(int accountId);
        void UpdateAccount(Account account);
    }
}