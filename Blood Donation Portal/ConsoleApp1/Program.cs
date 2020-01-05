using System;
using System.Threading;
using Hospital_Microservice.Models;
using Hospital_Microservice.Persistence.Contexts;
using Notifications_Microservice.Models;
using Notifications_Microservice.Persistence.Contexts;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Feedback_Microservice.Persistence.Contexts.FeedbackDbContext feedbackDbContext = new Feedback_Microservice.Persistence.Contexts.FeedbackDbContext();
            NotificationsDbContext db = new NotificationsDbContext();
        }
    }
}