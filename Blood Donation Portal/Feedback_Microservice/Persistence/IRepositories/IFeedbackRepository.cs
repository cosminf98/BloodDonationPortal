using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feedback_Microservice.Models;

namespace Feedback_Microservice.Repositories
{
    public interface IFeedbackRepository
    {
        Task<IEnumerable<Feedback>> GetFeedbacksAsync();
        //Task<IEnumerable<Feedback>> GetHospitalsByCityAsync(string city);
    }
}
