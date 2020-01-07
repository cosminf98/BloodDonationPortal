using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Notifications_Microservice.Models;
using Notifications_Microservice.Persistence.Contexts;
using Notifications_Microservice.Persistence.Repositories;

namespace Notifications_Microservice.Persistence.IRepositories
{
    public class CallToActionRepository : BaseRepository, ICallToActionRepository
    {
        public CallToActionRepository(NotificationsDbContext context) : base(context) { }


        public async Task<PublicNotification> NotifyWhenBloodIsNeeded(string city, string country, string bloodTypeNeeded, string donationCenter)
        {
            PublicNotification notification = new PublicNotification { BloodTypeNeeded = bloodTypeNeeded, City = city,
                County = country, DonationCenter = donationCenter };
            await _context.PublicNotifications.AddAsync(notification);
            await _context.SaveChangesAsync();
            return notification;
        }



        public async void SendEmailWhenBloodIsNeeded(string email,string subject,string content)
        {
            try
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("EmailInfo.json");
                var configuration = builder.Build();
                var host = configuration["Gmail:Host"];
                var port = int.Parse(configuration["Gmail:Port"]);
                var username = configuration["Gmail:Username"];
                var password = configuration["Gmail:Password"];
                var enable = bool.Parse(configuration["Gmail:SMTP:starttls:enable"]);

                var smtpClient = new SmtpClient()
                {
                    Host = host,
                    Port = port,
                    EnableSsl = enable,
                    Credentials = new NetworkCredential(username, password)
                };

                var message = new MailMessage("", email);
                message.Subject = subject;
                message.Body = content;
                await smtpClient.SendMailAsync(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
