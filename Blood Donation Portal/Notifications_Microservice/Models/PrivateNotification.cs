﻿using System;

namespace Notifications_Microservice.Models
{
    public class PrivateNotification
    {
        public Guid Id { get; set; }
        public string DonorEmail { get; set; }
        public bool IsSeen { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}