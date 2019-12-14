using System;
using System.Text.Json.Serialization;

namespace Hospital_Microservice.Models
{
    public class DatesAndLocations
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string City { get; set; }
        public Guid MobileBloodBankId{ get; set; }
        [JsonIgnore]
        public MobileBloodBank MobileBloodBank { get; set; }
    }
}