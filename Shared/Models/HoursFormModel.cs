using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Shared.Models
{
    public class HoursFormModel
    {

        public int FormId { get; set; }
        public int AccountId { get; set; }

        [DisplayName("Ingeleverd op")]
        public DateTime? DateSend { get; set; }

        [DisplayName("Uiterste inleverdatum")]
        public DateTime? DateDue { get; set; }

        [DisplayName("Totaal aantal uren")]
        public int TotalHours { get; set; }

        [DisplayName("Maand")]
        public string ProjectMonth { get; set; }

        [DisplayName("Jaar")]
        public int Year { get; set; }

        [DisplayName("Keuring opdrachtgever")]
        public bool? IsAcceptedClient { get; set; }

        [DisplayName("Gesloten")]
        public bool IsLocked { get; set; }
    }
}
