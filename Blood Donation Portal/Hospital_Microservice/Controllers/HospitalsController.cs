using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hospital_Microservice.Models;
using Hospital_Microservice.Persistence.Contexts;
using Hospital_Microservice.Services;

namespace Hospital_Microservice.Controllers
{
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

        // GET: api/Hospitals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hospital>>> GetHospitals()
        {
            return await _context.Hospitals.ToListAsync();
        }

        // GET: api/Hospitals/city
        [HttpGet("{city}")]
        public async Task<ActionResult<IEnumerable<Hospital>>> GetHospitalsByCity(string city)
        {
            var cities = await _service.GetHospitalsByCityAsync(city);
            if (cities == null)
                return NotFound();

            return cities.ToList();
        }

        //GET: api/Hospitals/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Hospital>> GetHospital(Guid id)
        //{
        //    var hospital = await _context.Hospitals.FindAsync(id);

        //    if (hospital == null)
        //    {
        //        return NotFound();
        //    }

        //    return hospital;
        //}

        //// PUT: api/Hospitals/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutHospital(Guid id, Hospital hospital)
        //{
        //    if (id != hospital.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(hospital).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!HospitalExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Hospitals
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPost]
        //public async Task<ActionResult<Hospital>> PostHospital(Hospital hospital)
        //{
        //    _context.Hospitals.Add(hospital);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetHospital", new { id = hospital.Id }, hospital);
        //}

        //// DELETE: api/Hospitals/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Hospital>> DeleteHospital(Guid id)
        //{
        //    var hospital = await _context.Hospitals.FindAsync(id);
        //    if (hospital == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Hospitals.Remove(hospital);
        //    await _context.SaveChangesAsync();

        //    return hospital;
        //}

        private bool HospitalExists(Guid id)
        {
            return _context.Hospitals.Any(e => e.Id == id);
        }
    }
}
