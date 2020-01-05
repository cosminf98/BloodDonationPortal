using Hospital_Microservice.Models;
using Hospital_Microservice.Persistence.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
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

        public async Task<MobileBloodBank> DeleteMobileBloodBank(Guid id)
        {
            var mb = await _repo.DeleteMobileBloodBank(id);
            return mb;
        }

        public async Task<MobileBloodBank> GetMobileBloodBankAsync(Guid id) => await _repo.GetMobileBloodBankAsync(id);

        public async Task<ActionResult<IEnumerable<MobileBloodBank>>> GetMobileBloodBanksAsync()
        {
            return await _repo.GetMobileBloodBanksAsync();
        }

        public async Task<MobileBloodBank> PatchMobileBloodBank(Guid id, JsonPatchDocument<MobileBloodBank> patchBank)
            => await _repo.PatchMobileBloodBank(id, patchBank);

        public bool Authorize(ClaimsIdentity identity, string type)
        {
            try
            {
                var claim = identity.FindFirst(type).Value;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
