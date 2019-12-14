using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hospital_Microservice.Models;
using Hospital_Microservice.Persistence.Contexts;
using Hospital_Microservice.Persistence.Repositories;
using Hospital_Microservice.Services;
using Microsoft.AspNetCore.JsonPatch;

namespace Hospital_Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileBloodBanksController : ControllerBase
    {
        private readonly HospitalDbContext _context;
        private readonly IMobileBloodBankService _service;

        public MobileBloodBanksController(HospitalDbContext context, IMobileBloodBankService service)
        {
            _context = context;
            _service = service;
        }

        // GET: api/MobileBloodBanks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MobileBloodBank>>> GetMobileBloodBanks()
        {
            return await _context.MobileBloodBanks.ToListAsync();
        }

        // GET: api/MobileBloodBanks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MobileBloodBank>> GetMobileBloodBank(Guid id)
        {
            var bank = await _service.GetMobileBloodBankAsync(id);
            if (bank == null) return NotFound();
            return bank;

        }

        [HttpPost]
        public async Task<ActionResult<MobileBloodBank>> PostMobileBloodBank(MobileBloodBank mobileBloodBank)
        {
            await _service.AddBankAsync(mobileBloodBank);
            return CreatedAtAction("GetMobileBloodBank", new { id = mobileBloodBank.Id }, mobileBloodBank);
        }



        // DELETE: api/MobileBloodBanks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MobileBloodBank>> DeleteMobileBloodBank(Guid id)
        {
            var mobileBloodBank = await _context.MobileBloodBanks.FindAsync(id);
            if (mobileBloodBank == null)
            {
                return NotFound();
            }

            _context.MobileBloodBanks.Remove(mobileBloodBank);
            await _context.SaveChangesAsync();

            return mobileBloodBank;
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<MobileBloodBank>> PatchMobileBloodBank(Guid id, [FromBody] JsonPatchDocument<MobileBloodBank> patchBank)
        {
            MobileBloodBank bank = await _service.PatchMobileBloodBank(id, patchBank);
            if (bank == null) return NotFound();
            return Ok(bank);
        }

        private bool MobileBloodBankExists(Guid id)
        {
            return _context.MobileBloodBanks.Any(e => e.Id == id);
        }
    }
}
