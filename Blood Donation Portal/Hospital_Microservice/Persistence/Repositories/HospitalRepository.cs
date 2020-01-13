using Hospital_Microservice.Models;
using Hospital_Microservice.Persistence.Contexts;
using Hospital_Microservice.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Microservice.Persistence.Repositories
{
    public class HospitalRepository : BaseRepository, IHospitalRepository
    {
        public HospitalRepository(HospitalDbContext context) : base(context) {}

        public async Task<Hospital> GetHospitalById(Guid id)
        {
            return await _context.Hospitals.Include(h => h.Schedules).SingleAsync(h => h.Id == id);
        }

        public async Task<IEnumerable<Hospital>> GetHospitalsAsync()
        {
            return await _context.Hospitals.ToListAsync();
        }

        public async Task<IEnumerable<Hospital>> GetHospitalsByCityOrCountyAsync(string cityOrCounty)
        {
            return await _context.Hospitals.Where(h => h.City.Contains(cityOrCounty) || h.County.Contains(cityOrCounty)).ToListAsync();
        }

        public async Task<ActionResult<Hospital>> HospitalRegister(Hospital hospital)
        {
            _context.Hospitals.Add(hospital);
            await _context.SaveChangesAsync();
            return hospital;
        }

        public async Task<IEnumerable<Schedule>> PatchSchedules(string email, JsonPatchDocument<Hospital> patchHospitalProgram)
        {
            Hospital hospital = await _context.Hospitals.Where(h => email.ToLower().Equals(h.Email.ToLower())).SingleAsync();
            if (hospital == null) return null;

            patchHospitalProgram.ApplyTo(hospital);
            await _context.SaveChangesAsync();
            return hospital.Schedules;
        }
    }
}
