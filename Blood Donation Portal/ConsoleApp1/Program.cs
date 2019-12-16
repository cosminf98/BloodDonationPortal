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
            HospitalDbContext hcontext = new HospitalDbContext();
            Hospital hospital = new Hospital()
            {
                Name = "Centru de transfuzie",
                City = "Iasi",
                County = "Iasi",
                Address = "Pe undeva prin Iasi",
                PhoneNumber = "0757328193"
            };
            LoginDetails login = new LoginDetails()
            {
                Email = "CTEmail@email.com",
                Password = "sggdrhr"
            };
            Schedule schedule = new Schedule()
            {
                DayOfWeek = "Luni,Marti,Miercuri,Joi,Vineri",
                IsOpen = false,
                OpenFrom = 480,
                OpenUntil = 900
            };
            hospital.LoginDetails = login;
            hospital.Schedules.Add(schedule);

            hcontext.Hospitals.Add(hospital);
            hcontext.SaveChanges();

            /* NotificationsDbContext context = new NotificationsDbContext();
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
                 Console.WriteLine(x.CreatedAt);*/
        }
    }
}