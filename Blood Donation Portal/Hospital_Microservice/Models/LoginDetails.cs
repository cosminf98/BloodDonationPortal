using System;
using System.Text.Json.Serialization;

namespace Hospital_Microservice.Models
{
    public class LoginDetails
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid HospitalId { get; set; }

        [JsonIgnore]
        public Hospital Hospital { get; set; }
    }
}
