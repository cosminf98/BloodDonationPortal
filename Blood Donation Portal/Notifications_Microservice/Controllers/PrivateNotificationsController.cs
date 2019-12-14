using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [HttpGet("{email}")]
        public async Task<ActionResult<IEnumerable<PrivateNotification>>> GetPrivateNotifications(string email)
        {
            var notifications = await _service.GetNotifications(email);
            return notifications.ToList();
        }

        // POST: api/PrivateNotifications/notify/gigel@email.com
        [HttpPost("notify/{email}")]
        public async Task<ActionResult<PrivateNotification>> PostPrivateNotification(string email, [FromBody]PrivateNotification privateNotification)
        {
            await _service.NotifyDonorWhenBloodIsUsed(email);
            return Ok();
        }

        //// GET: api/PrivateNotifications/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<PrivateNotification>> GetPrivateNotification(Guid id)
        //{
        //    var privateNotification = await _context.PrivateNotifications.FindAsync(id);

        //    if (privateNotification == null)
        //    {
        //        return NotFound();
        //    }

        //    return privateNotification;
        //}

        //// PUT: api/PrivateNotifications/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPrivateNotification(Guid id, PrivateNotification privateNotification)
        //{
        //    if (id != privateNotification.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(privateNotification).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PrivateNotificationExists(id))
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



        //// DELETE: api/PrivateNotifications/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<PrivateNotification>> DeletePrivateNotification(Guid id)
        //{
        //    var privateNotification = await _context.PrivateNotifications.FindAsync(id);
        //    if (privateNotification == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.PrivateNotifications.Remove(privateNotification);
        //    await _context.SaveChangesAsync();

        //    return privateNotification;
        //}

        private bool PrivateNotificationExists(Guid id)
        {
            return _context.PrivateNotifications.Any(e => e.Id == id);
        }
    }
}
