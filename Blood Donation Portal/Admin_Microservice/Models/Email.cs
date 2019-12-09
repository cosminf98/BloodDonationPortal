using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace Admin_Microservice.Models
{

    public class Email
    {
        private static string subject = "New information about your blood donation subscription!" ;
        private static string updateContent = "";
        private static string emergencyContent = "";
        static async void SendMultipleMails(List<string> emailAdresses)
        {
            foreach(string email in emailAdresses)
            {
                Send(email, updateContent);
            }
        }
        static async void Send(string toAdress,string content)
        {
            try
            {
                var builder = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("LoginInfo.json");
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

                var message = new MailMessage("", toAdress);
                message.Subject = Email.subject;
                message.Body = content;
                await smtpClient.SendMailAsync(message);
                Console.WriteLine("Done");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
