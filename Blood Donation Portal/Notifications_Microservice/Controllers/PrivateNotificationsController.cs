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
    public class PrivateNotificationsController : ControllerBase
    {
        private readonly NotificationsDbContext _context;
        private readonly INotificationService _service;

        public PrivateNotificationsController(NotificationsDbContext context,INotificationService service)
        {
            _context = context;
            _service = service;
        }

        // GET: api/PrivateNotifications/gigelEmail@email.com
        [Authorize]
        [HttpGet("{email}")]
        public async Task<ActionResult<IEnumerable<PrivateNotification>>> GetPrivateNotifications(string email)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string uemail = identity.FindFirst("DonorEmail").Value;
            if (_service.Authorize(identity,"DonorEmail") && uemail == email)
            {
                var notifications = await _service.GetNotifications(email);
                return Ok(notifications.ToList());
            }
            return Unauthorized();
        }

        // POST: api/PrivateNotifications/notify/gigel@email.com
        [Authorize]
        [HttpPost("notify/{email}")]
        public async Task<ActionResult<PrivateNotification>> PostPrivateNotification(string email, [FromBody]PrivateNotification privateNotification)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (_service.Authorize(identity, "HospitalEmail"))
            {
                await _service.NotifyDonorWhenBloodIsUsed(email);
                return Ok();
            }
            else
                return Unauthorized();
        }


        private bool PrivateNotificationExists(Guid id)
        {
            return _context.PrivateNotifications.Any(e => e.Id == id);
        }
    }
}
