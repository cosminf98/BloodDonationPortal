using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Donor_Microservice.Models
{
    public class Donor : IdentityUser<Guid>
    {
        public Donor()
        {
            DonationsHistory = new HashSet<Donation>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BloodType { get; set; }
        public string City { get; set; }
        public string County { get; set; }

        public ICollection<Donation> DonationsHistory{ get; set; }

    }
}
