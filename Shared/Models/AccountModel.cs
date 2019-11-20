using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    public class AccountModel
    {
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public string HashedPassword { get; set; }
        public string Address { get; set; }
        public string ZIP { get; set; }
        public string MobilePhone { get; set; }
        public string City { get; set; }
        public string IBAN { get; set; }
        public DateTime? CreationDate { get; set; }
        public string ProfileImage { get; set; }


        public bool IsAdmin { get; set; }

        public bool IsTrainee { get; set; }

        public bool IsQienEmployee { get; set; }

        public bool IsSeniorDeveloper { get; set; }
        public bool IsActive { get; set; }
    }
}
