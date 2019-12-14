using Hospital_Microservice.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Microservice.Services
{
    public interface IMobileBloodBankService
    {
        public Task<MobileBloodBank> AddBankAsync(MobileBloodBank bank);
        public Task<MobileBloodBank> GetMobileBloodBankAsync(Guid id);
        public Task<MobileBloodBank> PatchMobileBloodBank(Guid id, JsonPatchDocument<MobileBloodBank> patchBank);
    }
}
