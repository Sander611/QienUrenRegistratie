using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models
{
    public class HoursPerDay
    {
        [Required]
        public int HoursPerDayId { get; set; }

        public int FormId { get; set; }
        [Required]
        public int Day { get; set; }
        [Required]
        public string Month { get; set; }
        [Required]
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
