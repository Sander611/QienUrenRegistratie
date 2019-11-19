using System.Collections.Generic;
using QienHoursRegistration.Models;
using System.Threading.Tasks;

namespace QienHoursRegistration.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> AddNewAccount(Account account);
        Task<List<Account>> GetAllAccounts();
        Task<Account> GetOneAccount(int accountId);
        Task<Account> ModifyAccountActivity(int accountId, bool IsActive);
        Task<Account> RemoveAccount(int accountId);
        Task<Account> UpdateAccount(Account account);
    }
}