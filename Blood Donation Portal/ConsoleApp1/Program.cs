using System;
using Admin_Microservice.Models;
using Admin_Microservice.Persistence.Contexts;
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
            //FeedbackDbContext context = new FeedbackDbContext();
            //IFeedbackService service = new FeedbackService(new FeedbackRepository(context));

            //Feedback feedback = new Feedback();
            //feedback.Email = "testemail";
            //feedback.Message = "message";

            //service.AddFeedbackAsync(feedback);
            //Console.WriteLine(feedback.Id);

            ////foreach(Feedback feed in context.Feedbacks)
            ////    Console.WriteLine(feed.Id + " " + feed.Message);
            ////Console.WriteLine("da");



        }
    }
}
