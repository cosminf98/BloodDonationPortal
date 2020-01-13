using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hospital_Microservice.Models;
using Hospital_Microservice.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Hospital_Microservice.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MobileBloodBanksController : ControllerBase
    {
        private readonly IMobileBloodBankService _service;

        public MobileBloodBanksController( IMobileBloodBankService service)
        {
            //_context = context;
            _service = service;
        }

        // GET: api/MobileBloodBanks
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MobileBloodBank>>> GetMobileBloodBanks()
        {
            //return await _context.MobileBloodBanks.ToListAsync();
            return await _service.GetMobileBloodBanksAsync();
        }

        // GET: api/MobileBloodBanks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MobileBloodBank>> GetMobileBloodBank(Guid id)
        {
            var bank = await _service.GetMobileBloodBankAsync(id);
            if (bank == null) return NotFound();
            return bank;
        }

        // POST : api/mobilebloodbanks
        [HttpPost]
        public async Task<ActionResult<MobileBloodBank>> PostMobileBloodBank(MobileBloodBank mobileBloodBank)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (_service.Authorize(identity, "HospitalEmail"))
            {
                await _service.AddBankAsync(mobileBloodBank);
                return CreatedAtAction("GetMobileBloodBank", new { id = mobileBloodBank.Id }, mobileBloodBank);
            }
                return Unauthorized("unauthored");
        }

        // DELETE: api/MobileBloodBanks/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<MobileBloodBank>> DeleteMobileBloodBank(Guid id)
        {

            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if(_service.Authorize(identity,"HospitalEmail"))
            { 
                var claim = identity.FindFirst("HospitalEmail").Value;
                var mb = await _service.DeleteMobileBloodBank(id);
                if (mb == null) return NotFound();
                return Ok(mb);
            }
            
            return Unauthorized("unauthored");

        }

        //PATCH: api/mobilebloodbanks/21
        [Authorize]
        [HttpPatch("{id}")]
        public async Task<ActionResult<MobileBloodBank>> PatchMobileBloodBank(Guid id, [FromBody] JsonPatchDocument<MobileBloodBank> patchBank)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if(_service.Authorize(identity,"HospitalEmail"))
            { 
                var claim = identity.FindFirst("HospitalEmail").Value;
                MobileBloodBank bank = await _service.PatchMobileBloodBank(id, patchBank);
                if (bank == null) return NotFound();
                return Ok(bank);
            }
            return Unauthorized();
        }

        //private bool MobileBloodBankExists(Guid id)
        //{
        //    return _context.MobileBloodBanks.Any(e => e.Id == id);
        //}
    }
}
