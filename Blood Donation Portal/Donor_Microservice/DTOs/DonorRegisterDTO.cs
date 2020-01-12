using System;

namespace Donor_Microservice.DTOs
{
    public class DonorRegisterDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BloodType { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Password { get; set; }

    }
}
