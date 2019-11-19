using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Models
{
    public class AdminTaskModel
    {
        public int accountId { get; set; }

        [DisplayName("Naam")]
        public string FullName { get; set; }

        [DisplayName("Info")]
        public string Info { get; set; }

        [DisplayName("Ingeleverd op")]
        public DateTime? HandInTime { get; set; }

        [DisplayName("Keuring opdrachtgever")]
        public bool? stateClientCheck { get; set; }
    }
}
