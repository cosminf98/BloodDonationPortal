using Notifications_Microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifications_Microservice.Persistence.IRepositories
{
    public interface ICallToActionRepository
    {
        public Task<PublicNotification> NotifyWhenBloodIsNeeded(string city, string country, string bloodTypeNeeded, string donationCenter);
        public void SendEmailWhenBloodIsNeeded(string email, string subject, string content);
    }
}
