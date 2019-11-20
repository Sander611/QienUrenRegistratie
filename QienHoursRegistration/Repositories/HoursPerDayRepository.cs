using Microsoft.EntityFrameworkCore;
using QienHoursRegistration.DataContext;
using Shared.Models;
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

        public async Task<HoursForm> CreateOneMonth(HoursForm hoursform)
        {
            var DaysinMonth = 0;

            switch (hoursperday.Month)
            {
                case "januari":
                    DaysinMonth = 31;
                    break;
                case "februari":
                    if (DateTime.IsLeapYear(hoursperday.Year) == true)
                    {
                        DaysinMonth = 29;
                    }
                    else
                    {
                        DaysinMonth = 28;
                    }
                    break;
                case "maart":
                    DaysinMonth = 31;
                    break;
                case "april":
                    DaysinMonth = 30;
                    break;
                case "mei":
                    DaysinMonth = 31;
                    break;
                case "juni":
                    DaysinMonth = 30;
                    break;
                case "juli":
                    DaysinMonth = 31;
                    break;
                case "augustus":
                    DaysinMonth = 31;
                    break;
                case "september":
                    DaysinMonth = 30;
                    break;
                case "oktober":
                    DaysinMonth = 31;
                    break;
                case "november":
                    DaysinMonth = 30;
                    break;
                case "december":
                    DaysinMonth = 31;
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
            return hoursform;
        }

        public async Task<List<HoursPerDay>> GetAllDaysFromOneForm(int formId)
        {
            var form = await context.HoursPerDays.SingleAsync(p => p.FormId == formId);
            return new List<HoursPerDay>
            {
               
            };
        }

       

        public async Task<HoursPerDay> SaveADay(HoursPerDay dayedit)
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
            return dayedit;
        }

        public async Task<HoursPerDay> Update(HoursPerDay daychange)
        {
            var entity = context.HoursPerDays.Single(p => p.HoursPerDayId == daychange.HoursPerDayId);
            entity.Day = daychange.Day;
            entity.Hours = daychange.Hours;
            entity.Month = entity.Month;
            entity.Year = entity.Year;
            entity.IsLeave = daychange.IsLeave;
            entity.IsSick = daychange.IsSick;
            entity.Other = daychange.Other;
            entity.OverTimeHours = daychange.OverTimeHours;
            entity.ProjectDay = daychange.ProjectDay;
            entity.Reasoning = daychange.Reasoning;
            entity.ClientId = entity.ClientId;

            await context.SaveChangesAsync();

            return entity;
        }
    }
}
