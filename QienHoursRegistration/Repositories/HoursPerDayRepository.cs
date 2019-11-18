using QienHoursRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QienHoursRegistration.Repositories
{
    public class HoursPerDayRepository
    {
        private readonly DbContext context;
        public HoursPerDayRepository (DbContext context)
        {
            this.context = context;
        }
        public HoursPerDay GetNewSingleDay()
        {
            return new HoursPerDay
            { 
            }; 
        }
        public void SaveADay(HoursPerDay dayedit)
        {
            context.HoursPerDay.Add(new HoursPerDay
            {
                HoursPerDayId = dayedit.HoursPerDayId,
                ClientId = dayedit.ClientId,
                Day = dayedit.Day,
                Month = dayedit.Month,
                Other = dayedit.Other,
                Hours = dayedit.Hours,
                FormId = dayedit.FormId,
                Training = dayedit.Training,
                Year = dayedit.Year,
                IsLeave = dayedit.IsLeave,
                IsSick = dayedit.IsSick,
                ProjectDay = dayedit.ProjectDay,
                OverTimeHours = dayedit.OverTimeHours,
                Reasoning = dayedit.Reasoning
            });
            context.SaveChanges();
        }

    }
}
