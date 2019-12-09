using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feedback_Microservice.Persistence.Contexts;
using Feedback_Microservice.Persistence.IRepositories;
using Feedback_Microservice.Persistence.Repositories;
using Feedback_Microservice.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Feedback_Microservice
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //TODO ; move to appsettinsjson
            services.AddDbContext<FeedbackDbContext>(options =>
            {
                options.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Feedbacks;Trusted_Connection=True; Initial Catalog=FeedbackDb;Integrated Security=SSPI;");
            });


            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IFeedbackService, FeedbackService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
