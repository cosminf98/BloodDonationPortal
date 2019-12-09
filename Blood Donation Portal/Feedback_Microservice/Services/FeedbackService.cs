using Feedback_Microservice.Models;
using Feedback_Microservice.Persistence.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback_Microservice.Services
{
    public class FeedbackService : IFeedbackService
    {
        readonly IFeedbackRepository _repository;
        public FeedbackService(IFeedbackRepository repo)
        {
            this._repository = repo;
        }

        public async Task<Feedback> AddFeedbackAsync(Feedback feedback)
        {
            return await _repository.AddFeedbackAsync(feedback);
        }

        public async Task<Feedback> GetFeedbackAsync(Guid id)
        {
            return await _repository.GetFeedbackAsync(id);
        }

        public async Task<IEnumerable<Feedback>> GetFeedbacksAsync()
        {
            return await _repository.GetFeedbacksAsync();
        }
    }
}
