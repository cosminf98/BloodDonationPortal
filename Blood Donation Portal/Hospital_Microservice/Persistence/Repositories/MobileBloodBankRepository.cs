using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital_Microservice.Models;
using Hospital_Microservice.Persistence.Contexts;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Microservice.Persistence.Repositories
{
    public class MobileBloodBankRepository : BaseRepository, IMobileBloodBankRepository
    {
        public MobileBloodBankRepository(HospitalDbContext context) : base(context) { }

        public async Task<MobileBloodBank> AddBankAsync(MobileBloodBank bank)
        {
            await _context.MobileBloodBanks.AddAsync(bank);
            await _context.SaveChangesAsync();
            return bank;
        }

        public async Task<MobileBloodBank> GetMobileBloodBankAsync(Guid id)
        {
            MobileBloodBank bank = await _context.MobileBloodBanks
                .Include(mb => mb.DatesAndLocations)
                .SingleOrDefaultAsync(mb => mb.Id == id);

            return bank;

        }
        public async Task<MobileBloodBank> PatchMobileBloodBank(Guid id, JsonPatchDocument<MobileBloodBank> patchBank)
        {
            MobileBloodBank bank = await _context.MobileBloodBanks.FindAsync(id);
            if (bank == null) return null;

            patchBank.ApplyTo(bank);
            await _context.SaveChangesAsync();
            return bank;
        }
    }
}
