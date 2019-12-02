using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback_Microservice.Models
{
    public class LoginDetails
    {
        public Guid FeedbackId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public Feedback Feedback { get; set; }
    }
}
