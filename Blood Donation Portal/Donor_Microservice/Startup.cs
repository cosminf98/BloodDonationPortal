using Donor_Microservice.Persistence;
using Donor_Microservice.Persistence.IRepositories;
using Donor_Microservice.Persistence.Repositories;
using Donor_Microservice.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Donor_Microservice
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
            services.AddDbContext<DonorDbContext>(options =>
            {
                options.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Donors;Trusted_Connection=True; Initial Catalog=DonorDb;Integrated Security=SSPI;");
            });


            services.AddScoped<IDonorRepository, DonorRepository>();
            services.AddScoped<IDonorService, DonorService>();

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
