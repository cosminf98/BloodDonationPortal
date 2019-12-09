using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback_Microservice.Models
{
    public class Feedback
    {
        public Feedback() { }
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
    }
}
