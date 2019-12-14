using Donor_Microservice.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Donor_Microservice.Persistence.IRepositories
{
    public interface IDonorRepository
    {
        public Task<Donation> AddDonationToDonorHistoryAsync(string email, Donation donation);
        public Task<IEnumerable<Donation>> GetDonorHistory(Guid id);
        public Task<IEnumerable<LoginDetails>> GetDonorsFromRegion(string city, string country, string bloodType);
    }
}
