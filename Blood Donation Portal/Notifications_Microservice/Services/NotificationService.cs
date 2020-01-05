using Notifications_Microservice.Models;
using Notifications_Microservice.Persistence.IRepositories;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Notifications_Microservice.Services
{
    public class NotificationService : INotificationService
    {
        readonly INotificationRepository _repo;
        public NotificationService(INotificationRepository repo)
        {
            this._repo = repo;
        }

        public async Task<IEnumerable<PrivateNotification>> GetNotifications(string email)
        {
            return await _repo.GetNotifications(email);
        }

        public async Task<PrivateNotification> NotifyDonorWhenBloodIsUsed(string email)
        {
            return await _repo.NotifyDonorWhenBloodIsUsed(email);
        }

        public bool Authorize(ClaimsIdentity identity,string type)
        {
            try
            {
                var claim = identity.FindFirst(type).Value;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
