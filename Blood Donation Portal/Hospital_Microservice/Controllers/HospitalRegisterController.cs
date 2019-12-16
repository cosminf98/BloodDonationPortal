using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hospital_Microservice.Models;
using Hospital_Microservice.Persistence.Contexts;
using Hospital_Microservice.Services;

namespace Hospital_Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalRegisterController : ControllerBase
    {
        private readonly HospitalDbContext _context;
        private readonly IHospitalService _service;

        public HospitalRegisterController(HospitalDbContext context, IHospitalService service)
        {
            _context = context;
            _service = service;
        }

        // POST: api/HospitalRegister
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Hospital>> PostHospital([FromBody] RegisterInformation info)
        {
            if (HospitalExists(info.Email))
            {
                return BadRequest();
            }

            await _service.HospitalRegister(info);

            return Ok();
        }

        private bool HospitalExists(String email)
        {
            return _context.LoginDetails.Any(e => e.Email == email);
        }
    }
}
