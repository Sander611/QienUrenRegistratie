using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Shared.Models
{
    [Table("Client")]
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        [ForeignKey("Account")]
        public int AccountId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string ClientName1 { get; set; }
        public string ClientName2 { get; set; }
        [Required]
        [Email]
        [Remote(action: "VerifyEmail", controller: "ClientController")]
        public string ClientEmail1 { get; set; }
        [Email]
        [Remote(action: "VerifyEmail", controller: "ClientController")]
        public string ClientEmail2 { get; set; }
    }
}
}
