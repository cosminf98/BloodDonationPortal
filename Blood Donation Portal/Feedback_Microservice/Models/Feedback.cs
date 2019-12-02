using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback_Microservice.Models
{
    public class Feedback
    {
        public Feedback()
        {

        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }

        public Guid LoginDetailsId { get; set; }
        public LoginDetails LoginDetails { get; set; }

    }
}
