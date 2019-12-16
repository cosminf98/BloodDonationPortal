using Hospital_Microservice.Models;
using Hospital_Microservice.Persistence.Contexts;
using Hospital_Microservice.Repositories;
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
        public async Task<IEnumerable<Hospital>> GetHospitalsAsync()
        {
            return await _context.Hospitals.ToListAsync();
        }

        public async Task<IEnumerable<Hospital>> GetHospitalsByCityAsync(string city)
        {
            return await _context.Hospitals.Where(h => h.City.Contains(city)).ToListAsync();
        }

        public async Task<ActionResult<Hospital>> HospitalRegister(Hospital hospital)
        {
            _context.Hospitals.Add(hospital);
            await _context.SaveChangesAsync();
            return hospital;
        }
    }
}
