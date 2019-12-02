using Feedback_Microservice.Models;
using Feedback_Microservice.Persistence.Contexts;
using Feedback_Microservice.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback_Microservice.Persistence.Repositories
{
    public class FeedbackRepository : BaseRepository, IFeedbackRepository
    {
        public FeedbackRepository(FeedbackDbContext context) : base(context) {}
        public async Task<IEnumerable<Feedback>> GetFeedbacksAsync()
        {
            return await _context.Feedbacks.ToListAsync();
        }

        //public async Task<IEnumerable<Hospital>> GetHospitalsByCityAsync(string city)
        //{
            //return await _context.Hospitals.Where(h => h.City.Contains(city)).ToListAsync();
        //}
    }
}
