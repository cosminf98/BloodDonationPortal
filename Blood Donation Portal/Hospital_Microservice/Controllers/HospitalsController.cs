using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hospital_Microservice.Models;
using Hospital_Microservice.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.JsonPatch;

namespace Hospital_Microservice.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalsController : ControllerBase
    {
        //private readonly HospitalDbContext _context;
        private readonly IHospitalService _service;

        public HospitalsController(IHospitalService service)
        {
            //_context = context;
            _service = service;
        }

        // GET: api/Hospitals/city
        [HttpGet("{cityOrCounty}")]
        public async Task<ActionResult<IEnumerable<Hospital>>> GetHospitalsByCity(string cityOrCounty)
        {
            var cities = await _service.GetHospitalsByCityOrCountyAsync(cityOrCounty);
            if (cities == null) return NotFound();

            return cities.ToList();
        }

        
        [HttpPatch("modifyprogram/{email}")]
        public async Task<ActionResult<IEnumerable<Schedule>>> PatchSchedule(string email, [FromBody] JsonPatchDocument<Hospital> patchHospitalProgram)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            IEnumerable<Schedule> schedules =  await _service.PatchSchedules(email, patchHospitalProgram);
            return Ok(schedules);

        }

        //[HttpPost("addprogram/{email}")]
        //public async Task<ActionResult<IEnumerable<Schedule>>> PatchSchedule(string email, [FromBody] JsonPatchDocument<Hospital> patchHospitalProgram)
        //{
        //    var identity = HttpContext.User.Identity as ClaimsIdentity;


        //}

        //private bool HospitalExists(Guid id)
        //{
        //    return _context.Hospitals.Any(e => e.Id == id);
        //}
    }
}
