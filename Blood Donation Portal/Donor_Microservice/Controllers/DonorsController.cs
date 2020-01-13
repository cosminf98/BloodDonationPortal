using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Donor_Microservice.Models;
using Donor_Microservice.Persistence;
using Donor_Microservice.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Hospital_Microservice.AuthorizationRequirements;
using System.Text;
using System.Net.Http;

namespace Donor_Microservice.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DonorsController : ControllerBase
    {
        private readonly DonorDbContext _context;
        private readonly IDonorService _service;

        public DonorsController(DonorDbContext context, IDonorService service)
        {
            _context = context;
            _service = service;
        }

        // GET: api/Donors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donor>>> GetDonors()
        {
            return await _context.Donors.ToListAsync();
        }

        // GET: api/Donors/iselligible/id
        [HttpGet("iselligible/{id}")]   
        public async Task<bool> IsElligible(Guid id)
        {
            return await _service.CheckIfElligible(id);
        }

        //GET: api/Donors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Donor>> GetDonor(Guid id)
        {
            var donor = await _context.Donors.FindAsync(id);

            if (donor == null)
            {
                return NotFound();
            }

            return donor;
        }

        //GET: api/gethistory/5
        [Authorize]
        [HttpGet("gethistory/{id}")]
        public async Task<ActionResult<IEnumerable<Donation>>> GetHistory(Guid id)
        {
            var history = await _service.GetDonorHistory(id);
            if (history == null)
            {
                return NotFound("not found");
            }
            
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string uid = identity.FindFirst("Id").Value;

            //check for matching ids, so one user can't see other's history
            if (_service.Authorize(identity,"DonorEmail") && id.ToString() == uid)
                return history.ToList();
            return Unauthorized("Unauth");
        }

        //POST: api/donors/addtohistory/email
        [Authorize]
        [HttpPost("addtohistory/{email}")]
        public async Task<ActionResult<Donor>> PostDonation(string email, [FromBody] Donation donation)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (_service.Authorize(identity,"HospitalEmail"))
            {
                await _service.AddDonationToDonorHistoryAsync(email, donation);
                return Ok();
            }
            return Unauthorized("Unauth");
        }
    }
}
