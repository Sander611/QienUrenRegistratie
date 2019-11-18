using System.Collections.Generic;
using QienHoursRegistration.Models;

namespace QienHoursRegistration.Repositories
{
    public interface IHoursFormRepository
    {
        void EditForm(HoursForm editform);
        List<HoursForm> GetAllHoursForms();
        HoursForm GetHoursForm();
        HoursForm GetSingleAccountForms();
        HoursForm GetSingleForm();
    }
}