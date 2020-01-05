using Hospital_Microservice.AuthorizationRequirements;
using Hospital_Microservice.Models;
using Hospital_Microservice.Persistence.Contexts;
using Hospital_Microservice.Persistence.Repositories;
using Hospital_Microservice.Repositories;
using Hospital_Microservice.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;



namespace Hospital_Microservice
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
            services.AddIdentity<Hospital, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<HospitalDbContext>();

            services.AddControllers()
                .AddNewtonsoftJson();

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

                    ValidIssuer = Constants.Issuer,
                    ValidAudience = Constants.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.Secret))
                };
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
            });
            //TODO ; move to appsettinsjson
            services.AddDbContext<HospitalDbContext>(options =>
            {
                options.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Hospitals;Trusted_Connection=True; Initial Catalog=HospitalDb;Integrated Security=SSPI;");
                //options.UseSqlServer(Configuration.GetConnectionString("AppData")); when moving to appsetings
            });


            services.AddScoped<IHospitalRepository, HospitalRepository>();
            services.AddScoped<IHospitalService, HospitalService>();
            services.AddScoped<IMobileBloodBankRepository, MobileBloodBankRepository>();
            services.AddScoped<IMobileBloodBankService, MobileBloodBankService>();
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

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

    }
}
