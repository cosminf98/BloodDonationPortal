using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donor_Microservice.DTOs
{
    public class CallToActionDTO
    {
        public string County { get; set; }
        public string BloodTypeNeeded { get; set; }
        public string HospitalCenter { get; set; }

    }
}
