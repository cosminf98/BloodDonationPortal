using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feedback_Microservice.Models;
using Feedback_Microservice.Repositories;

namespace Feedback_Microservice.Services
{
    public class FeedbackService : IFeedbackService
    {
        readonly IFeedbackRepository _feedbackRepository;
        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            this._feedbackRepository = feedbackRepository;
        }

        public async Task<IEnumerable<Feedback>> GetFeedbacksAsync()
        {
            return await _feedbackRepository.GetFeedbacksAsync();
        }

        //public async Task<IEnumerable<Hospital>> GetHospitalsByCityAsync(string city)
        //{
            //return await _hospitalRepository.GetHospitalsByCityAsync(city);
        //}
    }
}
