using Hospital_Microservice.AuthorizationRequirements;
using Donor_Microservice.Models;
using Donor_Microservice.Persistence;
using Donor_Microservice.Persistence.IRepositories;
using Donor_Microservice.Persistence.Repositories;
using Donor_Microservice.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

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
            services.AddCors();
            services.AddIdentity<Donor, AppRole>(options =>
             {
                 options.User.RequireUniqueEmail = true;
             }).AddEntityFrameworkStores<DonorDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = Hospital_Microservice.AuthorizationRequirements.Constants.Issuer,
                    ValidAudience = Hospital_Microservice.AuthorizationRequirements.Constants.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Hospital_Microservice.AuthorizationRequirements.Constants.Secret))
                };
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
            });
            //services.AddScoped<IAuthorizationHandler, DonorRequireClaimHandler>();

            services.AddControllers();
            //TODO ; move to appsettinsjson
            services.AddDbContext<DonorDbContext>(options =>
            {
                options.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Donors;Trusted_Connection=True; Initial Catalog=DonorDb;Integrated Security=SSPI;");
                //options.UseSqlServer(Configuration.GetConnectionString("AppData")); when moving to appsetings
            });


            services.AddScoped<IDonorRepository, DonorRepository>();
            services.AddScoped<IDonorService, DonorService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

       app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials()
            );


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();



            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
