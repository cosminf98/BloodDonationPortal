using Feedback_Microservice.Persistence.Contexts;

namespace Feedback_Microservice.Persistence.Repositories
{

    public abstract class BaseRepository
    {
        protected readonly FeedbackDbContext _context;

        public BaseRepository(FeedbackDbContext context)
        {
            _context = context;
        }
    }
}
