using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin_Microservice.Models
{
    public class LoginDetails
    {
        public Guid AdminId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Admin Admin { get; set; }

    }
}
