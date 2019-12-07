using System;
using System.Linq;
using Admin_Microservice.Persistence.Contexts;
using Donor_Microservice.Models;
using Donor_Microservice.Persistence;
using Feedback_Microservice.Models;
using Feedback_Microservice.Persistence.Contexts;
using Feedback_Microservice.Persistence.Repositories;
using Feedback_Microservice.Services;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DonorDbContext context = new DonorDbContext();

            Donor donor = new Donor();
            donor.BloodType = "rh+";
            donor.FirstName = "Gigel";
            donor.LastName = "Franaru";
            donor.Gender = "m";
            donor.City = "Roman";
            donor.DateOfBirth = DateTime.Now;

            LoginDetails lg = new LoginDetails();
            lg.Email = "gigelemail";
            lg.Password = "password";

            Donation donation = new Donation();
            donation.DonationCenter = "Center";
            donation.DonationDate = DateTime.Now;

            context.Donors.Add(donor);
            context.SaveChanges();
            context.Donors.Where(d => d.Gender.Equals("m")).Single().LoginDetails = lg;
            context.Donors.Where(d => d.Gender.Equals("m")).Single().DonationsHistory.Add(donation);
            context.SaveChanges();

            var alist = context.Donors;
            foreach(var donor2 in alist)
            {
                Console.WriteLine(context.Donors.Find(donor2.Id).LoginDetails.Email);
                foreach(var var2 in context.Donors.Find(donor2.Id).DonationsHistory)
                    Console.WriteLine(var2.DonationCenter);
            }
            Console.WriteLine("da");

        }
    }
}
