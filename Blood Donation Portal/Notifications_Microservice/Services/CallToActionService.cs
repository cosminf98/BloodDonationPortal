using System.Collections.Generic;
using System.Threading.Tasks;
using Notifications_Microservice.Models;
using Notifications_Microservice.Persistence.IRepositories;

namespace Notifications_Microservice.Services
{
    public class CallToActionService : ICallToActionService
    {
        readonly ICallToActionRepository _repo;
        public CallToActionService(ICallToActionRepository repo)
        {
            this._repo = repo;
        }
 

        public async Task<PublicNotification> NotifyWhenBloodIsNeeded(string city, string country, string bloodTypeNeeded, string donationCenter)
        {
            return await _repo.NotifyWhenBloodIsNeeded(city,country,bloodTypeNeeded,donationCenter);
        }


        public void SendEmailWhenBloodIsNeeded(string email, string subject, string content) => _repo.SendEmailWhenBloodIsNeeded(email, subject, content);
    }
}
