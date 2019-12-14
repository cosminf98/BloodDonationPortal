using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notifications_Microservice.Models;
using Notifications_Microservice.Services;

namespace Notifications_Microservice.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CallToActionController : ControllerBase
    {
        private readonly NotificationsDBContext _context;
        private readonly ICallToActionService _service;

        CallToActionController(NotificationsDBContext notificationsDBContext ,ICallToActionService callToActionService )
        {
            _context = notificationsDBContext;
            _service = callToActionService;
        }
        // GET: api/CallToAction
        [HttpGet]
        public void SendEmail(string email, string subject, string content)
        {
            _service.SendEmailWhenBloodIsNeeded(email, subject, content);
        }

        // GET: api/CallToAction/5
        //[HttpGet("{id}", Name = "Get")]
        //public void SendEmail(string email, string subject, string content)
        //{
        //    _service.SendEmailWhenBloodIsNeeded(email, subject, content);

        //}

        // POST: api/CallToAction
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/CallToAction/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
