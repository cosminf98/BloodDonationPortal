using Donor_Microservice.Models;
using Donor_Microservice.Persistence.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donor_Microservice.Persistence.Repositories
{
    public class DonorRepository : BaseRepository, IDonorRepository
    {
        public DonorRepository(DonorDbContext context) : base(context) {}

        public async Task<Donation> AddDonationToDonorHistoryAsync(string email, Donation donation)
        {
            Donor donor = _context.Donors.Where(d => d.LoginDetails.Email.ToLower().Equals(email.ToLower())).Single();
            donor.DonationsHistory.Add(donation);
            await _context.SaveChangesAsync();
            return donation;
        }

        public async Task<IEnumerable<Donation>> GetDonorHistory(Guid id)
        {
            var history = await _context.Donations.Where(don => don.DonorId == id).ToListAsync();
            return history.ToList();
        }

        public async Task<IEnumerable<LoginDetails>> GetDonorsFromRegion(string city, string country, string bloodType)
        {
            var list = await _context.LoginDetails.Where(donor => donor.Donor.City.Equals(city.ToLower()) &&
            donor.Donor.Country.Equals(country.ToLower()) && donor.Donor.BloodType.Equals(bloodType.ToLower())).ToListAsync();

            return list.ToList();
        }
    }
}
