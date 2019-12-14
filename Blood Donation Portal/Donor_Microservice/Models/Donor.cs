using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donor_Microservice.Models
{
    public class Donor
    {
        public Donor()
        {
            DonationsHistory = new HashSet<Donation>();
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BloodType { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool IsElligible { get; set; }

        //public Guid LoginDetailsId { get; set; }
        public LoginDetails LoginDetails { get; set; }
        public ICollection<Donation> DonationsHistory{ get; set; }

    }
}
