using System.Collections.Generic;
using QienHoursRegistration.DataContext;
using System.Threading.Tasks;
using Shared.Models;
namespace QienHoursRegistration.Repositories
{
    public interface IAccountRepository
    {
        Task<AccountModel> AddNewAccount(AccountModel account);
        Task<List<AccountModel>> GetAllAccounts();
        Task<AccountModel> GetOneAccount(int accountId);
        Task<AccountModel> ModifyAccountActivity(int accountId, bool IsActive);
        void RemoveAccount(int accountId);
        Task<AccountModel> UpdateAccount(AccountModel account);
    }
}