using Donor_Microservice.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donor_Microservice.Persistence
{
    public class DonorDbContext : IdentityDbContext<Donor,AppRole,Guid>
    {

        public DonorDbContext(DbContextOptions<DonorDbContext> options) : base(options) { }
        public DonorDbContext(){
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO : move connection string to appsettings.json
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Donors;Trusted_Connection=True; Initial Catalog=DonorDb;Integrated Security=SSPI;");
        }

        public DbSet<Donor> Donors { get; set; }
        public DbSet<Donation> Donations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Setting Primary Keys
            builder.Entity<Donor>()
                .HasKey(d => d.Id);
            builder.Entity<Donation>()
                .HasKey(d => d.Id);

            //Setting Constraints
            builder.Entity<Donor>().Property("BloodType").IsRequired().HasMaxLength(3);
            builder.Entity<Donor>().Property("Gender").IsRequired().HasMaxLength(1);
            builder.Entity<Donor>().Property("City").IsRequired();

            builder.Entity<Donation>().Property("DonationDate").IsRequired();
            builder.Entity<Donation>().Property("DonationCenter").IsRequired();


            builder.Entity<Donor>()
                .HasMany(d => d.DonationsHistory)
                .WithOne(don => don.Donor)
                .HasForeignKey(don => don.DonorId);

        }
    }
}
