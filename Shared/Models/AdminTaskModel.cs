using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Models
{
    public class AdminTaskModel
    {
        public int formId { get; set; }
        public int accountId { get; set; }

        [DisplayName("Naam")]
        public string FullName { get; set; }

        [DisplayName("Info")]
        public string Info { get; set; }
        [DisplayName("Maand")]
        public string Month { get; set; }
        [DisplayName("Year")]
        public string Year { get; set; }

        [DisplayName("Ingeleverd op")]
        public DateTime? HandInTime { get; set; }

        [DisplayName("Keuring opdrachtgever")]
        public bool? stateClientCheck { get; set; }
    }
}
