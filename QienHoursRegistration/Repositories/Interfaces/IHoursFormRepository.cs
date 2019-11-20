using System.Collections.Generic;
using System.Threading.Tasks;
using QienHoursRegistration.DataContext;

namespace QienHoursRegistration.Repositories
{
    public interface IHoursFormRepository
    {
        void EditForm(HoursForm editform);
        Task<List<HoursForm>> GetAllHoursForms();
        HoursForm GetHoursForm(HoursForm hoursformmodel);
        Task<HoursForm> GetSingleAccountForms(int id);
        Task<HoursForm> GetSingleForm(int id);

        Task<List<HoursForm>> GetAllClientAcceptedForms();
    }
}