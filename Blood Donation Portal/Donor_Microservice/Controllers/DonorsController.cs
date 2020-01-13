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
using Donor_Microservice.DTOs;

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

        //GET: api/Donors/5
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
		
        [AllowAnonymous]
        [HttpPost("calltoaction")]
        public ActionResult SendMail([FromBody] CallToActionDTO callToActionDTO)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (_service.Authorize(identity, "HospitalEmail"))
            {
                if (_service.CallToAction(callToActionDTO.BloodTypeNeeded, callToActionDTO.HospitalCenter, callToActionDTO.County))
                    return Ok();
                return BadRequest("Something went wrong, try again!");

            }
            return Unauthorized();
        }

        //PATCH: api/donors/modifydonordata/email
        [Authorize]
        [HttpPatch("modifydonordata/{email}")]
        public async Task<ActionResult<InformationToModify>> ModifyDonorData(string email, [FromBody] InformationToModify info)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (_service.Authorize(identity, "DonorEmail"))
            {
                var infos = await _service.ModifyDonorData(email, info);
                return Ok(infos);
            }
            return Unauthorized("Unauth");
        }

    }
}
