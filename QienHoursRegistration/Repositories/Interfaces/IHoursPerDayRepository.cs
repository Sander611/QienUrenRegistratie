using System.Collections.Generic;
using QienHoursRegistration.Models;

namespace QienHoursRegistration.Repositories
{
    public interface IHoursPerDayRepository
    {
        void CreateOneMonth(HoursForm hoursform);
        void SaveADay(HoursPerDay dayedit);

        void Update(HoursPerDay daychange);
    }
}