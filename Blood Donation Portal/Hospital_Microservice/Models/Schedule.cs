using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Microservice.Models
{
    public class Schedule
    {
        public Guid ScheduleId { get; set; }
        public string DayOfWeek { get; set; }
        public bool IsOpen { get; set; }
        //hour of opening. (as minutes since start of day)
        //for example 630 means 10:30
        public int? OpenFrom { get; set; }
        //closing hour.
        public int? OpenUntil { get; set; }
        public Guid HospitalId { get; set; }

        public Hospital Hospital { get; set; }
    }
}
