using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Donor_Microservice.Models
{
    public class Donation
    {
        public Guid Id { get; set; }
        public DateTime DonationDate { get; set; }
        public string DonationCenter { get; set; }

        public Guid DonorId { get; set; }
        [JsonIgnore]
        public Donor Donor { get; set; }

    }
}
