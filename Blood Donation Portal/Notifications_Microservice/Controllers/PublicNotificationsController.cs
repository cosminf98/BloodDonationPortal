using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        /*
        * GET: api/PublicNotifications/neamt/roman
        * This also deletes older notifications
        */
        [Authorize]
        [HttpGet("{county}/{city}")]
        public async Task<ActionResult<IEnumerable<PublicNotification>>> GetPublicNotifications(string? city,string? county)
        { 
                var notifications = await _service.GetPublicNotificationsAsync(city, county);
                if (notifications == null) return NotFound();
                return Ok(notifications.ToList());
        }

        // GET: api/PublicNotifications/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicNotification>> GetPublicNotification(Guid id)
        {
            var publicNotification = await _service.GetPublicNotificationAsync(id);

            if (publicNotification == null)
            {
                return NotFound();
            }
            return Ok(publicNotification);
        }


        // POST: api/PublicNotifications
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<PublicNotification>> PostPublicNotification(PublicNotification publicNotification)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if(_service.Authorize(identity,"HospitalEmail"))
            {
                await _service.PostPublicNotificationAsync(publicNotification);
                return CreatedAtAction("GetPublicNotification", new { id = publicNotification.Id }, publicNotification);
            }
            else
                return Unauthorized("unauthored");
        }


        // DELETE: api/PublicNotifications/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicNotification>> DeletePublicNotification(Guid id)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (_service.Authorize(identity, "HospitalEmail"))
            {
                var claim = identity.FindFirst("HospitalEmail").Value;
                return await _service.DeletePublicNotificationAsync(id);
            }
            else
                return Unauthorized();
        }

        private bool PublicNotificationExists(Guid id)
        {
            return _context.PublicNotifications.Any(e => e.Id == id);
        }
    }
}
