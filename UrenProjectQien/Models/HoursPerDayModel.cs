using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrenProjectQien.Models
{
    public class HoursPerDayModel
    {
        public int HoursPerDayId { get; set; }

        public int FormId { get; set; }

        public int Day { get; set; }
        public string Month { get; set; }
        
        public int Year { get; set; }
        public int Hours { get; set; }
        public int OverTimeHours { get; set; }
        public int Training { get; set; }
        public bool IsLeave { get; set; }
        public string Other { get; set; }
        public string Reasoning { get; set; }
        public string ProjectDay { get; set; }

        public int ClientId { get; set; }
        public bool IsSick { get; set; }
    }
}
