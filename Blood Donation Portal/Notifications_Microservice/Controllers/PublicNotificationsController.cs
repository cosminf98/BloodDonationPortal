using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Notifications_Microservice.Models;
using Notifications_Microservice.Persistence.Contexts;
using Notifications_Microservice.Services;

namespace Notifications_Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicNotificationsController : ControllerBase
    {
        private readonly NotificationsDbContext _context;
        private readonly IPublicNotificationService _service;

        public PublicNotificationsController(NotificationsDbContext context,IPublicNotificationService service)
        {
            _context = context;
            _service = service;
        }

        //to delete
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<PublicNotification>>> GetPublicNotifications2(string? city, string? county)
        {
            return Ok((await _context.PublicNotifications.ToListAsync()));
        }

        /*
        * GET: api/PublicNotifications/neamt/roman
        * This also deletes older notifications
        */
        [HttpGet("{county}/{city}")]
        public async Task<ActionResult<IEnumerable<PublicNotification>>> GetPublicNotifications(string? city,string? county)
        {
            var notifications = await _service.GetPublicNotificationsAsync(city, county);
            if (notifications== null) return NotFound();
            return Ok(notifications.ToList());
        }

        // GET: api/PublicNotifications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicNotification>> GetPublicNotification(Guid id)
        {
            var publicNotification = await _context.PublicNotifications.FindAsync(id);

            if (publicNotification == null)
            {
                return NotFound();
            }

            return Ok(publicNotification);
        }

        // POST: api/PublicNotifications
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PublicNotification>> PostPublicNotification(PublicNotification publicNotification)
        {
            await _service.PostPublicNotificationAsync(publicNotification);
            return CreatedAtAction("GetPublicNotification", new { id = publicNotification.Id }, publicNotification);
        }

        // PUT: api/PublicNotifications/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublicNotification(Guid id, PublicNotification publicNotification)
        {
            if (id != publicNotification.Id)
            {
                return BadRequest();
            }

            _context.Entry(publicNotification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicNotificationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }



        // DELETE: api/PublicNotifications/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicNotification>> DeletePublicNotification(Guid id)
        {
            var publicNotification = await _context.PublicNotifications.FindAsync(id);
            if (publicNotification == null)
            {
                return NotFound();
            }

            _context.PublicNotifications.Remove(publicNotification);
            await _context.SaveChangesAsync();

            return publicNotification;
        }

        private bool PublicNotificationExists(Guid id)
        {
            return _context.PublicNotifications.Any(e => e.Id == id);
        }
    }
}
