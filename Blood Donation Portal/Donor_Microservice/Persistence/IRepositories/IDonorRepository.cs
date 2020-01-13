using Donor_Microservice.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Donor_Microservice.Persistence.IRepositories
{
    public interface IDonorRepository
    {
        public Task<Donation> AddDonationToDonorHistoryAsync(string email, Donation donation);
        public Task<IEnumerable<Donation>> GetDonorHistory(Guid id);
        public Task<Donor> GetDonorAsync(Guid id);
        public Task<ActionResult<Donor>> DonorRegister(Donor donor);
        public Task<InformationToModify> ModifyDonorData(string email, InformationToModify info);

        public IEnumerable<string> GetDonorEmails(string county);


    }
}
