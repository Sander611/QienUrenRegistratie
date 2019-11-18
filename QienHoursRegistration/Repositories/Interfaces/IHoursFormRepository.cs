using System.Collections.Generic;
using System.Threading.Tasks;
using QienHoursRegistration.Models;

namespace QienHoursRegistration.Repositories
{
    public interface IHoursFormRepository
    {
        void EditForm(HoursForm editform);
        Task<List<HoursForm>> GetAllHoursForms();
        Task<HoursForm> GetHoursForm(HoursForm hoursformmodel);
        Task<HoursForm> GetSingleAccountForms();
        Task<HoursForm> GetSingleForm();
    }
}