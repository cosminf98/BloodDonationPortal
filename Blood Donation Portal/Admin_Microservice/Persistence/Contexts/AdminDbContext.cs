using Microsoft.EntityFrameworkCore;
using Admin_Microservice.Models;

namespace Admin_Microservice.Persistence.Contexts
{
    public class AdminDbContext : DbContext
    {
        public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options) { }
        public AdminDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO : move connection string to appsettings.json
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Admins;Trusted_Connection=True; Initial Catalog=AdminDb;Integrated Security=SSPI;");
        }

        public DbSet<Admin> Admins{ get; set; }
        public DbSet<LoginDetails> LoginDetails{ get; set; }
        public DbSet<MobileBloodBank> MobileBloodBanks { get; set; }
        public DbSet<DatesAndLocations> DatesAndLocations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Setting keys
            builder.Entity<Admin>().HasKey(a => a.Id);
            builder.Entity<LoginDetails>().HasKey(lg => lg.AdminId);
            builder.Entity<MobileBloodBank>().HasKey(mbb => mbb.Id);
            builder.Entity<DatesAndLocations>().HasKey(dal=> dal.Id);

            //Setting constraints
            builder.Entity<LoginDetails>().Property("Password").IsRequired().HasMaxLength(64);
            builder.Entity<LoginDetails>().Property("Email").IsRequired();

            builder.Entity<MobileBloodBank>().Property("Name").IsRequired();

            builder.Entity<DatesAndLocations>().Property("Date").IsRequired();
            builder.Entity<DatesAndLocations>().Property("City").IsRequired();


            builder.Entity<Admin>()
                .HasOne(a => a.LoginDetails)
                .WithOne(lg => lg.Admin)
                .HasForeignKey<LoginDetails>(lg => lg.AdminId);

            builder.Entity<MobileBloodBank>()
                .HasMany(m => m.DatesAndLocations)
                .WithOne(d => d.MobileBloodBank)
                .HasForeignKey(d => d.MobileBloodBankId);

        }
    }
}