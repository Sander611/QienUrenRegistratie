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

        private readonly HoursPerDay hoursperday;
        public HoursPerDayRepository (HoursPerDay hoursperday)
        {
            this.hoursperday = hoursperday;
        }
        public HoursPerDay GetNewSingleDay()
        {
            return new HoursPerDay
            { 
            }; 
        }

        public void CreateOneMonth(HoursForm hoursform)
        {
            var DaysinMonth = 0;

            switch (hoursperday.Month) {
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
                DaysinMonth--;
                context.HoursPerDay.add(new HoursPerDay
                {
                    FormId = hoursform.FormId
                });
                context.SaveChanges();
            }
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
