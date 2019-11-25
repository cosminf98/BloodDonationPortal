using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donor_Microservice.Models
{
    public class Donation
    {
        public Guid DonorId { get; set; }
        public DateTime DonationDate { get; set; }
        public string DonationCenter { get; set; }

        public Donor Donor { get; set; }

    }
}
