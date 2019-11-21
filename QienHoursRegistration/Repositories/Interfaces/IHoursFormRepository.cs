using System.Collections.Generic;
using System.Threading.Tasks;
using QienHoursRegistration.DataContext;
using Shared.Models;

namespace QienHoursRegistration.Repositories
{
    public interface IHoursFormRepository
    {
        Task<HoursFormModel> EditForm(HoursFormModel editform);
        Task<List<HoursFormModel>> GetAllHoursForms();

        Task<List<HoursFormModel>> GetSingleAccountForms(int id);

        Task<HoursFormModel> CreateNewForm(HoursFormModel hoursFormModel);
        Task<List<AdminTaskModel>> GetAllClientAcceptedForms();
    }
}