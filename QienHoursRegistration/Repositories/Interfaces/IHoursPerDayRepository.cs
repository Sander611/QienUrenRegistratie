using System.Collections.Generic;
using System.Threading.Tasks;
using QienHoursRegistration.DataContext;

namespace QienHoursRegistration.Repositories
{
    public interface IHoursPerDayRepository
    {
        Task<HoursForm> CreateOneMonth(HoursForm hoursform);

        Task<HoursPerDay> Update(HoursPerDay daychange);
      
    }
}