using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Models;

namespace QienHoursRegistration.Repositories
{
    public interface IHoursPerDayRepository
    {
        Task<HoursForm> CreateOneMonth(HoursForm hoursform);
        Task<HoursPerDay> SaveADay(HoursPerDay dayedit);

        Task<HoursPerDay> Update(HoursPerDay daychange);
      
    }
}