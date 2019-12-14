using Microsoft.EntityFrameworkCore;
using Notifications_Microservice.Models;
using Notifications_Microservice.Persistence.Contexts;
using Notifications_Microservice.Persistence.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifications_Microservice.Persistence.IRepositories
{
    public class NotificationRepository : BaseRepository, INotificationRepository
    {
        public NotificationRepository(NotificationsDbContext context) : base(context) { }

        public async Task<IEnumerable<PrivateNotification>> GetNotifications(string email)
        {
            var userNotifications =  await _context.PrivateNotifications.Where(n => n.DonorEmail.ToLower().Equals(email.ToLower())).ToListAsync();
            return userNotifications;
        }

        public async Task<PrivateNotification> NotifyDonorWhenBloodIsUsed(string email)
        {
            PrivateNotification notification = new PrivateNotification
            {
                DonorEmail = email
            };
            await _context.PrivateNotifications.AddAsync(notification);
            await _context.SaveChangesAsync();
            return notification;
        }
    }
}
