using System;


namespace Notifications_Microservice.Models
{
    public class PublicNotification
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string BloodTypeNeeded{ get; set; }
        public string DonationCenter { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
