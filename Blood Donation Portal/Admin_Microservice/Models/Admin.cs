using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin_Microservice.Models
{
    public class Admin
    {
        public Guid Id { get; set; }

        public Guid LoginDetailsId { get; set; }
        public LoginDetails LoginDetails { get; set; }

    }
}
