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
        [HttpGet("{email}")]
        public async Task<ActionResult<IEnumerable<PrivateNotification>>> GetPrivateNotifications(string email)
        {
            var notifications = await _service.GetNotifications(email);
            return Ok(notifications.ToList());
        }

        // POST: api/PrivateNotifications/notify/gigel@email.com
        [HttpPost("notify/{email}")]
        public async Task<ActionResult<PrivateNotification>> PostPrivateNotification(string email, [FromBody]PrivateNotification privateNotification)
        {
            await _service.NotifyDonorWhenBloodIsUsed(email);
            return Ok(privateNotification);
        }


        private bool PrivateNotificationExists(Guid id)
        {
            return _context.PrivateNotifications.Any(e => e.Id == id);
        }
    }
}
