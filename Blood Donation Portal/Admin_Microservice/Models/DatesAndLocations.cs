using System;
namespace Admin_Microservice.Models
{
    public class DatesAndLocations
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string City { get; set; }

        public Guid MobileBloodBankId{ get; set; }
        public MobileBloodBank MobileBloodBank { get; set; }
    }
}