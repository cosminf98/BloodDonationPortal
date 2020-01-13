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
            DonorDbContext db = new DonorDbContext();
        }
    }
}