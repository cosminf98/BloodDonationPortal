using Feedback_Microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback_Microservice.Services
{
    public interface IFeedbackService
    {
        Task<IEnumerable<Feedback>> GetFeedbacksAsync();
        //Task<IEnumerable<Feedback>> GetHospitalsByCityAsync(string city);
    }
}
