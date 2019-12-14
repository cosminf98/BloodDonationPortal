using System;
using System.Threading;
using Notifications_Microservice.Models;
using Notifications_Microservice.Persistence.Contexts;
using Notifications_Microservice.Services;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            NotificationsDbContext context = new NotificationsDbContext();
            PublicNotification pn2 = new PublicNotification()
            {
                BloodTypeNeeded = "o+",
                City = "Roman",
                DonationCenter = "Spital1"
            };
            PrivateNotification pn = new PrivateNotification()
            {
                DonorEmail = "GigelEmail@email.com"
            };
            context.PrivateNotifications.Add(pn);

            Thread.Sleep(1000);

            context.PublicNotifications.Add(pn2);
            context.SaveChanges();

            
            foreach(var x in context.PrivateNotifications)
                Console.WriteLine(x.CreatedAt);
        }
    }
}