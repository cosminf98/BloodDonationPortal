﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Donor_Microservice.Models;
using Donor_Microservice.Persistence;
using Donor_Microservice.Services;
using Hospital_Microservice.Models;

namespace Donor_Microservice.Controllers
{
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

        //// PUT: api/Donors/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutDonor(Guid id, Donor donor)
        //{
        //    if (id != donor.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(donor).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DonorExists(id))
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

        //// POST: api/Donors
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPost]
        //public async Task<ActionResult<Donor>> PostDonor(Donor donor)
        //{
        //    _context.Donors.Add(donor);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetDonor", new { id = donor.Id }, donor);
        //}

        //// DELETE: api/Donors/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Donor>> DeleteDonor(Guid id)
        //{
        //    var donor = await _context.Donors.FindAsync(id);
        //    if (donor == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Donors.Remove(donor);
        //    await _context.SaveChangesAsync();

        //    return donor;
        //}

        //private bool DonorExists(Guid id)
        //{
        //    return _context.Donors.Any(e => e.Id == id);
        //}
    }
}
