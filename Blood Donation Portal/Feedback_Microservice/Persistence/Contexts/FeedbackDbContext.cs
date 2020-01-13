using Feedback_Microservice.Models;
using Microsoft.EntityFrameworkCore;

namespace Feedback_Microservice.Persistence.Contexts
{
    public class FeedbackDbContext : DbContext
    {
        public FeedbackDbContext(DbContextOptions<FeedbackDbContext> options) : base(options) { }
        public FeedbackDbContext() { Database.EnsureCreated(); }

        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Setting Primary Keys
            builder.Entity<Feedback>()
                .HasKey(h => h.Id);

            //Setting constraints
            builder.Entity<Feedback>().Property(h => h.Message).IsRequired();
            builder.Entity<Feedback>().Property(h => h.Email).IsRequired();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO : move connection string to appsettings.json
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Feedbacks;Trusted_Connection=True; Initial Catalog=FeedbackDb;Integrated Security=SSPI;");

        }
    }
}
