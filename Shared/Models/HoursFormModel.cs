using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    public class HoursFormModel
    {

        public int FormId { get; set; }
        public int AccountId { get; set; }
        public DateTime? DateSend { get; set; }
        public DateTime? DateDue { get; set; }
        public int TotalHours { get; set; }
        public string ProjectMonth { get; set; }
        public int Year { get; set; }

        public bool? IsAcceptedClient { get; set; }

        public bool IsLocked { get; set; }
    }
}
