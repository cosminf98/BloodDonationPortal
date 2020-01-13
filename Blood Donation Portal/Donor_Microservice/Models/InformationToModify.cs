using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donor_Microservice.Models
{
    public class InformationToModify
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string County { get; set; }
    }
}
