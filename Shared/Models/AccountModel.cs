using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Shared.Models
{
    public class AccountModel
    {
        public int AccountId { get; set; }

        [DisplayName("Naam")]
        public string FirstName { get; set; }

        [DisplayName("Achternaam")]
        public string LastName { get; set; }

        [DisplayName("E-mailadres")]
        public string Email { get; set; }

        [DisplayName("Geboortedatum")]
        public DateTime? DateOfBirth { get; set; }

        public string HashedPassword { get; set; }

        [DisplayName("Adres")]
        public string Address { get; set; }

        [DisplayName("Postcode")]
        public string ZIP { get; set; }

        [DisplayName("Telefoonnummer")]
        public string MobilePhone { get; set; }

        [DisplayName("Woonplaats")]
        public string City { get; set; }

        [DisplayName("IBAN-nummer")]
        public string IBAN { get; set; }
        public DateTime? CreationDate { get; set; }
        public string ProfileImage { get; set; }


        public bool IsAdmin { get; set; }

        public bool IsTrainee { get; set; }

        public bool IsQienEmployee { get; set; }

        public bool IsSeniorDeveloper { get; set; }

        [DisplayName("Actief")]
        public bool IsActive { get; set; }
    }
}
