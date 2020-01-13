using Hospital_Microservice.Models;
using System.Collections.Generic;

namespace Hospital_Microservice.DTOs
{
    public class HospitalRegisterDTO
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<Schedule> Schedules { get; set; }

    }
}
