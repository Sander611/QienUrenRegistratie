using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Models;
namespace QienHoursRegistration.Repositories
{
    public interface IAccountRepository
    {
        Task<AccountModel> AddNewAccount(AccountModel account);
        Task<List<AccountModel>> GetAllAccounts(string searchString);
        Task<AccountModel> GetOneAccount(int accountId);
        Task<AccountModel> ModifyAccountActivity(int accountId, bool IsActive);
        string RemoveAccount(int accountId);
        Task<AccountModel> UpdateAccount(AccountModel account);
        Task<List<EmployeeDashboardModel>> getPersonaliaFromAccount(int accountId);
    }
}