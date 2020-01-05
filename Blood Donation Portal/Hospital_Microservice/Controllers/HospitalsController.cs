using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hospital_Microservice.Models;
using Hospital_Microservice.Persistence.Contexts;
using Hospital_Microservice.Services;
using Microsoft.AspNetCore.Authorization;

namespace Hospital_Microservice.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalsController : ControllerBase
    {
        private readonly HospitalDbContext _context;
        private readonly IHospitalService _service;

        public HospitalsController(HospitalDbContext context, IHospitalService service)
        {
            _context = context;
            _service = service;
        }

        // GET: api/Hospitals/city
        [HttpGet("{city}")]
        public async Task<ActionResult<IEnumerable<Hospital>>> GetHospitalsByCity(string cityOrCounty)
        {
            var cities = await _service.GetHospitalsByCityOrCountyAsync(cityOrCounty);
            if (cities == null) return NotFound();

            return cities.ToList();
        }

        private bool HospitalExists(Guid id)
        {
            return _context.Hospitals.Any(e => e.Id == id);
        }
    }
}
