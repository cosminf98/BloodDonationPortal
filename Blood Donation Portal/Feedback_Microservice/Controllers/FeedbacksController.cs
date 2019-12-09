using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Feedback_Microservice.Models;
using Feedback_Microservice.Persistence.Contexts;
using Feedback_Microservice.Services;

namespace Feedback_Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly FeedbackDbContext _context;
        private readonly IFeedbackService _service;

        public FeedbacksController(FeedbackDbContext context,IFeedbackService service)
        {
            _context = context;
            _service = service;
        }

        // POST: api/Feedbacks
        [HttpPost]
        public async Task<ActionResult<Feedback>> PostFeedback(Feedback feedback)
        {
            await _service.AddFeedbackAsync(feedback);
            return CreatedAtAction("GetFeedback", new { id = feedback.Id }, feedback);
        }

        // GET: api/Feedbacks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetFeedbacks()
        {
            var feedbacks =  await _service.GetFeedbacksAsync();
            if (feedbacks == null) return NotFound();
            return feedbacks.ToList();
        }
        // GET: api/Feedbacks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Feedback>> GetFeedback(Guid id)
        {
            var feedback = await _service.GetFeedbackAsync(id);

            if (feedback == null) return NotFound();
            
            return feedback;
        }
        private bool FeedbackExists(Guid id)
        {
            return _context.Feedbacks.Any(e => e.Id == id);
        }
    }
}
