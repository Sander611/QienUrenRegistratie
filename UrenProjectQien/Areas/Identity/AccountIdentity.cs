using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UrenProjectQien.Areas.Identity
{
    public class AccountIdentity : IdentityUser
    {
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string HashedPassword { get; set; }
        public string Address { get; set; }
        public string ZIP { get; set; }
        public string MobilePhone { get; set; }
        public string City { get; set; }
        public string IBAN { get; set; }
        public DateTime? CreationDate { get; set; }
        public string ProfileImage { get; set; }
       

    }
}
