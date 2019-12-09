﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Microservice.Models
{
    public class LoginDetails
    {
        public Guid HospitalId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Hospital Hospital { get; set; }
    }
}