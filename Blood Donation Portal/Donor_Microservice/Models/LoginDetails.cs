using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Donor_Microservice.Models
{
    public class LoginDetails
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Guid DonorId { get; set; }
        [JsonIgnore]
        public Donor Donor { get; set; }
    }
}
