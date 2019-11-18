using Microsoft.EntityFrameworkCore;
using QienHoursRegistration.DataContext;
using QienHoursRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QienHoursRegistration.Repositories
{
    public class HoursPerDayRepository : IHoursPerDayRepository
    {
        private readonly RepositoryContext context;
        public HoursPerDayRepository(RepositoryContext _context)
        {
            context = _context;
        }

        private readonly HoursPerDay hoursperday;
        public HoursPerDayRepository(HoursPerDay hoursperday)
        {
            this.hoursperday = hoursperday;
        }

        public async void CreateOneMonth(HoursForm hoursform)
        {
            var DaysinMonth = 0;

            switch (hoursperday.Month)
            {
                case "Januari":
                case "Maart":
                case "Mei":
                case "Juli":
                case "Augustus":
                case "Oktober":
                case "December":
                    DaysinMonth = 31;
                    break;
                case "Februari":
                    if (DateTime.IsLeapYear(hoursperday.Year) == true)
                    {
                        DaysinMonth = 29;
                    }
                    else
                    {
                        DaysinMonth = 28;
                    }
                    break;
                case "April":
                case "Juni":
                case "September":
                case "November":
                    DaysinMonth = 30;
                    break;
            }

            while (DaysinMonth > 0)
            {

                context.HoursPerDays.Add(new HoursPerDay
                {
                    FormId = hoursform.FormId,
                    Day = DaysinMonth,
                    Month = hoursperday.Month,
                    Year = hoursperday.Year

                });
                DaysinMonth--;
                await context.SaveChangesAsync();
            }
        }

        public async void SaveADay(HoursPerDay dayedit)
        {
            HoursPerDay newHoursPerDay = new HoursPerDay()
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
            };

            context.HoursPerDays.Add(newHoursPerDay);
            await context.SaveChangesAsync();
        }

        public async void Update(HoursPerDay daychange)
        {
            context.Entry(daychange).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
