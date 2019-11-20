using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QienHoursRegistration.DataContext
{
    [Table("HoursForm")]
    public class HoursForm
    {
        [Key]
        public int FormId { get; set; }
        [ForeignKey("Account")]
        [Required]
        public int AccountId { get; set; }
        public DateTime? DateSend { get; set; }
        public DateTime? DateDue { get; set; }
        public int TotalHours { get; set; }

        [Required]
        public string ProjectMonth { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public bool IsAcceptedClient { get; set; }

        public bool IsLocked { get; set; }
    }
}
