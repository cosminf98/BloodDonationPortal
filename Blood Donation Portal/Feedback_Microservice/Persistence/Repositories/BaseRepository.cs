using Feedback_Microservice.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
