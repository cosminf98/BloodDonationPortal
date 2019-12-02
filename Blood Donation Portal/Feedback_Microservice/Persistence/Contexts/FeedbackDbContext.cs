using Microsoft.EntityFrameworkCore;
using Feedback_Microservice.Models;

namespace Feedback_Microservice.Persistence.Contexts
{
    public class FeedbackDbContext : DbContext
    {
        public FeedbackDbContext(DbContextOptions<FeedbackDbContext> options) : base(options) {}
        public FeedbackDbContext(){}

        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<LoginDetails> LoginDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Setting Primary Keys
            builder.Entity<Feedback>()
                .HasKey(h => h.Id);
            builder.Entity<LoginDetails>().HasKey(lg => lg.FeedbackId);

            //Setting constraints
            builder.Entity<Feedback>().Property(h => h.Name).IsRequired();
            builder.Entity<Feedback>().Property(h => h.Subject).IsRequired();
            builder.Entity<Feedback>().Property(h => h.Email).IsRequired();
            builder.Entity<Feedback>().Property(h => h.Text).IsRequired();

            builder.Entity<LoginDetails>().Property(lg => lg.Email).IsRequired();
            builder.Entity<LoginDetails>().Property(lg => lg.Password).IsRequired().HasMaxLength(64);


            //Each Feedback has one loginDetails
            builder.Entity<Feedback>()
                .HasOne(h => h.LoginDetails)
                .WithOne(lg => lg.Feedback)
                .HasForeignKey<LoginDetails>(lg => lg.FeedbackId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO : move connection string to appsettings.json
            if(!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=FeedbackDb;Trusted_Connection=True;");

        }
    }
}
