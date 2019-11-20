﻿using System.Collections.Generic;
using System.Threading.Tasks;
using QienHoursRegistration.DataContext;
using Shared.Models;

namespace QienHoursRegistration.Repositories
{
    public interface IHoursPerDayRepository
    {

        Task<List<HoursPerDayModel>> Update(List<HoursPerDayModel> daychange);
        Task<List<HoursPerDayModel>> GetAllDaysForForm(int formId);
    }
}