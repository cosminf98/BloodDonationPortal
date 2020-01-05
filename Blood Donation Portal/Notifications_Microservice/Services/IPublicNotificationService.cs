using Notifications_Microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Notifications_Microservice.Services
{
    public interface  IPublicNotificationService
    {
        public Task<IEnumerable<PublicNotification>> GetPublicNotificationsAsync(string? city, string? county);
        public Task<PublicNotification> PostPublicNotificationAsync(PublicNotification notification);
        public Task<PublicNotification> DeletePublicNotificationAsync(Guid id);
        public Task<PublicNotification> GetPublicNotificationAsync(Guid id);

        public bool Authorize(ClaimsIdentity identity, string type);
    }
}
