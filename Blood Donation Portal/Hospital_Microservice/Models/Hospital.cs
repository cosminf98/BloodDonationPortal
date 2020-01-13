using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Hospital_Microservice.Models
{
    public class Hospital : IdentityUser<Guid>
    {
        public Hospital()
        {
            Schedules = new HashSet<Schedule>();
        }
        public string Name { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
