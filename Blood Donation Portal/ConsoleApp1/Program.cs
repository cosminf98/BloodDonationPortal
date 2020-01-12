using System;
using System.Threading;
using Admin_Microservice.Persistence.Contexts;
using Donor_Microservice.Persistence;
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
            //Feedback_Microservice.Persistence.Contexts.FeedbackDbContext feedbackDbContext = new Feedback_Microservice.Persistence.Contexts.FeedbackDbContext();
            //NotificationsDbContext db = new NotificationsDbContext();
            //HospitalDbContext hospitalDbContext = new HospitalDbContext();
            //AdminDbContext adminDbContext = new AdminDbContext();
            DonorDbContext donorDbContext = new DonorDbContext();
        }
    }
}