using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class HoursForm
    {
        [Required]
        public int FormId { get; set; }
        [Required]
        public int AccountId { get; set; }
        public DateTime? DateSend { get; set; }
        public DateTime? DateDue { get; set; }
        public int TotalHours { get; set; }
        public string ProjectMonth { get; set; }
        [Required]
        public bool IsAcceptedClient { get; set; }
    }
}
