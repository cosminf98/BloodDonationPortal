using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin_Microservice.Models
{
    public class MobileBloodBank
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }

        public ICollection<DatesAndLocations> DatesAndLocations{ get; set; }

    }
}
