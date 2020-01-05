using Microsoft.EntityFrameworkCore;
using Notifications_Microservice.Models;
using Notifications_Microservice.Persistence.Contexts;
using Notifications_Microservice.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifications_Microservice.Persistence.IRepositories
{
    public class PublicNotificationRepository : BaseRepository, IPublicNotificationRepository
    {
        public PublicNotificationRepository(NotificationsDbContext context) : base(context) { }

        public async Task<IEnumerable<PublicNotification>> GetPublicNotificationsAsync(string? city, string? county)
        {
            var notifications = await _context.PublicNotifications.
                Where(p => p.City.ToLower().Equals(city.ToLower())
                  || p.County.ToLower().Equals(county.ToLower())).ToListAsync();


            //remove old
            foreach (var notif in notifications)
                if ((DateTime.Now - notif.CreatedAt).Days >= 90) _context.PublicNotifications.Remove(notif);
            await _context.SaveChangesAsync();
            return notifications;
        }
        public async Task<PublicNotification> PostPublicNotificationAsync(PublicNotification notification)
        {
            await _context.PublicNotifications.AddAsync(notification);
            await _context.SaveChangesAsync();
            return notification;
        }
        public async Task<PublicNotification> DeletePublicNotificationAsync(Guid id)
        {
            PublicNotification notification = await _context.PublicNotifications.FindAsync(id);
            _context.PublicNotifications.Remove(notification);
            await _context.SaveChangesAsync();
            return notification;
        }

        public async Task<PublicNotification> GetPublicNotificationAsync(Guid id)
        {
            return await _context.PublicNotifications.FindAsync(id);
        }
    }
}
