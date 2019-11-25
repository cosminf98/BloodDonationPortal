using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Microservice.Models
{
    public class BloodType
    {
        public BloodType()
        {

        }
        public Guid BloodTypeId { get; set; }
        public string Type { get; set; }
        public int NumberOfPacks { get; set;}

        public Guid HospitalId { get; set; }
        public Hospital Hospital { get; set; }

    }
}
