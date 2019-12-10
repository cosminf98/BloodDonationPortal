using Notifications_Microservice.Persistence.Contexts;

namespace Notifications_Microservice.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly NotificationsDbContext _context;
        public BaseRepository(NotificationsDbContext context) { _context = context; }
    }
}
