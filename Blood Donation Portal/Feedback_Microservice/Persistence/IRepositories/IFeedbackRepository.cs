using Feedback_Microservice.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Feedback_Microservice.Persistence.IRepositories
{
    public interface IFeedbackRepository
    {
        Task<IEnumerable<Feedback>> GetFeedbacksAsync();
        Task<Feedback> GetFeedbackAsync(Guid id);
        Task<Feedback> AddFeedbackAsync(Feedback feedback);
    }
}
