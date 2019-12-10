using Notifications_Microservice.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notifications_Microservice.Services
{
    public interface INotificationService
    {
        public Task<PrivateNotification> NotifyDonorWhenBloodIsUsed(string email);
        public Task<IEnumerable<PrivateNotification>> GetNotifications(string email);
    }
}
