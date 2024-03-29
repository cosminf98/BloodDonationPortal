﻿using Donor_Microservice.Models;
using Donor_Microservice.Persistence.IRepositories;
using Microsoft.AspNetCore.Mvc;
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
            Donor donor = _context.Donors.Where(d => d.Email.ToLower().Equals(email.ToLower())).Single();
            donor.DonationsHistory.Add(donation);
            await _context.SaveChangesAsync();
            return donation;
        }
        public async Task<InformationToModify> ModifyDonorData(string email, InformationToModify info)
        {
            Donor donor = _context.Donors.Where(d => d.Email.ToLower().Equals(email.ToLower())).Single();
            if(info.FirstName != null)
                donor.FirstName = info.FirstName;
            if(info.LastName != null)
                donor.LastName = info.LastName;
            if(info.City != null)
                donor.City = info.City;
            if(info.County != null)
                donor.County = info.County;
            await _context.SaveChangesAsync();
            return info;
        }

        public async Task<Donor> GetDonorAsync(Guid id)
        {
            Donor donor = await _context.Donors.FindAsync(id);
            return donor;
        }

        public async Task<IEnumerable<Donation>> GetDonorHistory(Guid id)
        {
            var history = await _context.Donations.Where(don => don.DonorId == id).ToListAsync();
            return history.ToList();
        }
        public async Task<ActionResult<Donor>> DonorRegister(Donor donor)
        {
            _context.Donors.Add(donor);
            await _context.SaveChangesAsync();
            return donor;
        }

        public IEnumerable<string> GetDonorEmails(string county)
        {
            var emails = _context.Donors.Where(d => d.County.Contains(county)).Select(don => don.Email).ToList();
            return emails;
        }
    }
}
