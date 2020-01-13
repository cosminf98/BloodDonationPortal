using Microsoft.AspNetCore.Mvc;
using Notifications_Microservice.Services;

namespace Notifications_Microservice.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CallToActionController : ControllerBase
    {
        private readonly ICallToActionService _service;

        public CallToActionController(ICallToActionService callToActionService)
        {
            _service = callToActionService;
        }
        // GET: api/CallToAction
        [HttpPost("sendmail")]
        public ActionResult SendEmail()
        {
            _service.SendEmailWhenBloodIsNeeded("cosmin.sescu@gmail.com", "test", "altceva");
            return Ok();
        }

        // GET: api/CallToAction/5
        //[HttpGet("{id}", Name = "Get")]
        //public void SendEmail(string email, string subject, string content)
        //{
        //    _service.SendEmailWhenBloodIsNeeded(email, subject, content);

        //}

        // POST: api/CallToAction
        //[HttpPost]
        //public async Task<ActionResult<PublicNotification>> Post([FromBody]string city, [FromBody]string country, [FromBody] string bloodTypeNeeded, [FromBody] string donationCenter)
        //{
        //    await _service.NotifyWhenBloodIsNeeded(city, country, bloodTypeNeeded, donationCenter);
        //    return Ok();
        //}

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
