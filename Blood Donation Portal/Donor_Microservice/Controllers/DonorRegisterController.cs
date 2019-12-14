using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Donor_Microservice.Models;
using Donor_Microservice.Persistence;
using Donor_Microservice.Services;

namespace Donor_Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorRegisterController : ControllerBase
    {
        private readonly DonorDbContext _context;
        private readonly IDonorService _service;


        public DonorRegisterController(DonorDbContext context, IDonorService service)
        {
            _context = context;
            _service = service;
        }

        // POST: api/DonorRegister
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Donor>> PostDonor([FromBody]RegisterInformation info)
        {
            if (DonorExists(info.Email))
            {
                return BadRequest();
            }

            await _service.DonorRegister(info);

            return Ok();
        }


        private bool DonorExists(string email)
        {
            return _context.LoginDetails.Any(e => e.Email == email);
        }
    }
}
