using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donor_Microservice.DTOs
{
    public class DonorLoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
