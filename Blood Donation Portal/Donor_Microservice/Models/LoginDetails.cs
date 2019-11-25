using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donor_Microservice.Models
{
    public class LoginDetails
    {
        public Guid DonorId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Donor Donor { get; set; }
    }
}
