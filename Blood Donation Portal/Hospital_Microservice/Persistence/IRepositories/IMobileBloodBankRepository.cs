using Hospital_Microservice.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Threading.Tasks;

namespace Hospital_Microservice.Persistence.Repositories
{
    public interface IMobileBloodBankRepository
    {
        public Task<MobileBloodBank> AddBankAsync(MobileBloodBank bank);

        public Task<MobileBloodBank> GetMobileBloodBankAsync(Guid id);

        public Task<MobileBloodBank> PatchMobileBloodBank(Guid id, JsonPatchDocument<MobileBloodBank> patchBank);
    }
}
