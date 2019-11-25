using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Microservice.Models
{
    public class Hospital
    {
        public Hospital()
        {
            Schedules = new HashSet<Schedule>();
            BloodTypes = new HashSet<BloodType>();

        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public Guid LoginDetailsId { get; set; }
        public LoginDetails LoginDetails { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<BloodType> BloodTypes { get; set; }

    }
}
