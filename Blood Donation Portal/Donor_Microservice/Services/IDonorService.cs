using Donor_Microservice.Models;
using Hospital_Microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donor_Microservice.Services
{
    public interface IDonorService
    {
        Task<Donation> AddDonationToDonorHistoryAsync(string email, Donation donation);
        Task<IEnumerable<Donation>> GetDonorHistory(Guid id);

        Task<bool> CheckIfElligible(Guid id);
    }
}
