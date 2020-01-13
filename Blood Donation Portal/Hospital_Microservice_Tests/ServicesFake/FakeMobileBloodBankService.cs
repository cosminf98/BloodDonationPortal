using Hospital_Microservice.Models;
using Hospital_Microservice.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Microservice_Tests.ServicesFake
{
    class FakeMobileBloodBankService : IMobileBloodBankService
    {
        private readonly List<MobileBloodBank> _banks;

        public FakeMobileBloodBankService()
        {
            _banks = new List<MobileBloodBank>()
            {
                new MobileBloodBank(){Id= new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),Name="Mb1", About="aboot"},
                new MobileBloodBank(){Id= new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),Name="Mb2", About="aboot2"},
                new MobileBloodBank(){Id= new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad"),Name="Mb3", About="about"}
            };
        }
        public async Task<MobileBloodBank> AddBankAsync(MobileBloodBank bank)
        {
            bank.Id = new Guid();
            _banks.Add(bank);
            return bank;
        }


        public Task<MobileBloodBank> DeleteMobileBloodBank(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<MobileBloodBank> GetMobileBloodBankAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<IEnumerable<MobileBloodBank>>> GetMobileBloodBanksAsync()
        {
            return _banks;
        }

        public Task<MobileBloodBank> PatchMobileBloodBank(Guid id, JsonPatchDocument<MobileBloodBank> patchBank)
        {
            throw new NotImplementedException();
        }

        public bool Authorize(ClaimsIdentity identity, string type)
        {
            return true;
        }
    }
}
