using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Models;

namespace UrenProjectQien.Helper
{
    public interface IApiHelper
    {
        Task<IEnumerable<HoursPerDayModel>> AddHours(List<HoursPerDayModel> model);
        Task<IEnumerable<HoursPerDayModel>> GetHours(int formid);
    }
}