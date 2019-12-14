using System;
using System.Collections.Generic;

namespace Hospital_Microservice.Models
{
    public class MobileBloodBank
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }

        public ICollection<DatesAndLocations> DatesAndLocations{ get; set; }

    }
}
