using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Admin_Microservice.Models
{
    public class EmailInitializer
    {
        private static string Subject = null;
        private static string Content = null;
        private static List<string> listToSend;
        private static bool dataSet = false;
        static void DataSet(string sub,string con,List<string> sendList)
        {
            Subject = sub;
            Content = con;
            listToSend = sendList;
            dataSet = true;
        }
        static async void SendMultipleMails()
        {
            if (true == dataSet)
            {
                foreach (string email in listToSend)
                {
                    Send(email);
                }
            }
            else
            {
                ExceptionHandler("Data Not Set");
            }
        }
        
        static void ExceptionHandler(string exception)
        {
            /* To be implemented*/
        }

        static async void Send(string toAdress)
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

                var message = new MailMessage("", toAdress);
                message.Subject = EmailInitializer.Subject;
                message.Body = EmailInitializer.Content;
                await smtpClient.SendMailAsync(message);
                Console.WriteLine("Done");
            }
            catch (Exception e)
            {
                ExceptionHandler(e.Message);
            }
        }
    }
}
