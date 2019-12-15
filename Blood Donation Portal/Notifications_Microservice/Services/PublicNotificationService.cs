using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<PublicNotification>> GetPublicNotificationsAsync(string? city, string? county) =>
            await _repo.GetPublicNotificationsAsync(city, county);

        public async Task<PublicNotification> PostPublicNotificationAsync(PublicNotification notification) =>
            await _repo.PostPublicNotificationAsync(notification);

    }
}
