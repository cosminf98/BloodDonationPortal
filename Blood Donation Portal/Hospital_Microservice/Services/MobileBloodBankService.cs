using Hospital_Microservice.Models;
using Hospital_Microservice.Persistence.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Threading.Tasks;

namespace Hospital_Microservice.Services
{
    public class MobileBloodBankService : IMobileBloodBankService
    {
        readonly IMobileBloodBankRepository _repo;

        public MobileBloodBankService(IMobileBloodBankRepository repo)
        {
            _repo = repo;
        }

        public async Task<MobileBloodBank> AddBankAsync(MobileBloodBank bank) => await _repo.AddBankAsync(bank);

        public async Task<MobileBloodBank> GetMobileBloodBankAsync(Guid id) => await _repo.GetMobileBloodBankAsync(id);
        public async Task<MobileBloodBank> PatchMobileBloodBank(Guid id, JsonPatchDocument<MobileBloodBank> patchBank)
            => await _repo.PatchMobileBloodBank(id, patchBank);


    }
}
