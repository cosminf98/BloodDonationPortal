using Hospital_Microservice.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hospital_Microservice.Services
{
    public interface IMobileBloodBankService
    {
        public Task<MobileBloodBank> AddBankAsync(MobileBloodBank bank);
        public Task<MobileBloodBank> GetMobileBloodBankAsync(Guid id);
        public Task<MobileBloodBank> PatchMobileBloodBank(Guid id, JsonPatchDocument<MobileBloodBank> patchBank);

        public Task<MobileBloodBank> DeleteMobileBloodBank(Guid id);
        public Task<ActionResult<IEnumerable<MobileBloodBank>>> GetMobileBloodBanksAsync();

        public bool Authorize(ClaimsIdentity identity, string type);
    }
}
