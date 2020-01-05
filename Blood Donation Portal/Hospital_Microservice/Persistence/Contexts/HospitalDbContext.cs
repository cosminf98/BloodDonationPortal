using Microsoft.EntityFrameworkCore;
using Hospital_Microservice.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace Hospital_Microservice.Persistence.Contexts
{
    public class HospitalDbContext : IdentityDbContext<Hospital, AppRole, Guid>
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) {}
        public HospitalDbContext(){ Database.EnsureCreated(); }

        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<MobileBloodBank> MobileBloodBanks{ get; set; }
        public DbSet<DatesAndLocations> DatesAndLocations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Setting Primary Keys
            builder.Entity<Hospital>()
                .HasKey(h => h.Id);
            builder.Entity<Schedule>().HasKey(s => s.ScheduleId);
            builder.Entity<DatesAndLocations>().HasKey(dl => dl.Id);
            builder.Entity<MobileBloodBank>().HasKey(b => b.Id);

            //Setting constraints
            builder.Entity<Hospital>().Property(h => h.Name).IsRequired();
            builder.Entity<Hospital>().Property(h => h.City).IsRequired();
            builder.Entity<Hospital>().Property(h => h.Address).IsRequired();
            
            builder.Entity<Schedule>().Property(s => s.DayOfWeek).IsRequired().HasMaxLength(8);


            //Hospital has many Schedules(one for each day of week)
            builder.Entity<Hospital>()
                .HasMany(h => h.Schedules)
                .WithOne(p => p.Hospital)
                .HasForeignKey(p => p.HospitalId);

            builder.Entity<MobileBloodBank>()
                .HasMany(mb => mb.DatesAndLocations)
                .WithOne(p => p.MobileBloodBank)
                .HasForeignKey(p => p.MobileBloodBankId);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO : move connection string to appsettings.json
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Hospitals;Trusted_Connection=True; Initial Catalog=HospitalDb;Integrated Security=SSPI;");
        }
    }
}
