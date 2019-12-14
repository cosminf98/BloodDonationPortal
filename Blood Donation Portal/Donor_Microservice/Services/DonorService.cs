using Donor_Microservice.Models;
using Donor_Microservice.Persistence.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donor_Microservice.Services
{
    public class DonorService : IDonorService
    {
        readonly IDonorRepository _donorRepository;
        public DonorService(IDonorRepository donorRepository)
        {
            this._donorRepository = donorRepository;
        }

        public async Task<Donation> AddDonationToDonorHistoryAsync(string email, Donation donation)
        {
            await _donorRepository.AddDonationToDonorHistoryAsync(email, donation);
            return donation;
        }

        public async Task<IEnumerable<Donation>> GetDonorHistory(Guid id)
        {
            var history = await _donorRepository.GetDonorHistory(id);
            return history.ToList();
        }

        /*
         *  Max 3 times/year for women
         *  Max 4-5times/year for men
         *  At least 8 weeks(56 days) between donations
         */
        public async Task<bool> CheckIfElligible(Guid id)
        {
            //Get Donations made in the last year
            IEnumerable<Donation> history = (await GetDonorHistory(id)).
                Where(d => (DateTime.Now - d.DonationDate).Days < 365);
            if (history.Count() == 0) return true;

            if ((DateTime.Now - history.Last().DonationDate).Days <= 56) return false;

            if (history.Count() >= 5) return false;// We avoid a DB query whether it's male or female.
            else //if male he's elligible. If female we check again
            {
                Donor donor = await _donorRepository.GetDonorAsync(id);
                if (donor.Gender.ToLower() == "f" && history.Count() >= 3) return false;
            }
            return true;
        }
    }
}
