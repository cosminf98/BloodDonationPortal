using Microsoft.EntityFrameworkCore;
using Hospital_Microservice.Models;

namespace Hospital_Microservice.Persistence.Contexts
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) {}
        public HospitalDbContext(){}

        public DbSet<BloodType> BloodTypes { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<LoginDetails> LoginDetails { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Setting Primary Keys
            builder.Entity<Hospital>()
                .HasKey(h => h.Id);
            builder.Entity<BloodType>().HasKey(b => b.Type);
            builder.Entity<LoginDetails>().HasKey(lg => lg.HospitalId);
            builder.Entity<Schedule>().HasKey(s => s.ScheduleId);

            //Setting constraints
            builder.Entity<Hospital>().Property(h => h.Name).IsRequired();
            builder.Entity<Hospital>().Property(h => h.City).IsRequired();
            builder.Entity<Hospital>().Property(h => h.Address).IsRequired();

            builder.Entity<LoginDetails>().Property(lg => lg.Email).IsRequired();
            builder.Entity<LoginDetails>().Property(lg => lg.Password).IsRequired().HasMaxLength(64);

            builder.Entity<BloodType>().Property(bt => bt.Type).IsRequired().HasMaxLength(3);

            builder.Entity<Schedule>().Property(s => s.DayOfWeek).IsRequired().HasMaxLength(8);


            //Each hospital has one loginDetails
            builder.Entity<Hospital>()
                .HasOne(h => h.LoginDetails)
                .WithOne(lg => lg.Hospital)
                .HasForeignKey<LoginDetails>(lg => lg.HospitalId);

            //Hospital has many Schedules(one for each day of week)
            builder.Entity<Hospital>()
                .HasMany(h => h.Schedules)
                .WithOne(p => p.Hospital)
                .HasForeignKey(p => p.HospitalId);

            //Hospital has many BloodTypes(needed)
            builder.Entity<Hospital>()
                .HasMany(h => h.BloodTypes)
                .WithOne(bt => bt.Hospital)
                .HasForeignKey(bt => bt.HospitalId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO : move connection string to appsettings.json
            if(!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=HospitalDb;Trusted_Connection=True;");

        }
    }
}
