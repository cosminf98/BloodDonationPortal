using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Notifications_Microservice.Models;
using Notifications_Microservice.Persistence.IRepositories;

namespace Notifications_Microservice.Services
{
    public class PublicNotificationService : IPublicNotificationService
    {
        readonly IPublicNotificationRepository _repo;

        public PublicNotificationService(IPublicNotificationRepository repo)
        {
            _repo = repo;
        }

        public async Task<PublicNotification> DeletePublicNotificationAsync(Guid id)=>
            await _repo.DeletePublicNotificationAsync(id);

        public async Task<PublicNotification> GetPublicNotificationAsync(Guid id)
        {
            return await _repo.GetPublicNotificationAsync(id);
        }

        public async Task<IEnumerable<PublicNotification>> GetPublicNotificationsAsync(string? city, string? county) =>
            await _repo.GetPublicNotificationsAsync(city, county);

        public async Task<PublicNotification> PostPublicNotificationAsync(PublicNotification notification) =>
            await _repo.PostPublicNotificationAsync(notification);

        public bool Authorize(ClaimsIdentity identity, string type)
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
