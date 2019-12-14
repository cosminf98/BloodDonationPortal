using Notifications_Microservice.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notifications_Microservice.Services
{
    public interface ICallToActionService
    {
        public Task<PublicNotification> NotifyWhenBloodIsNeeded(string city, string country, string bloodTypeNeeded, string donationCenter);
        public void SendEmailWhenBloodIsNeeded(string email, string subject, string content);

    }
}
