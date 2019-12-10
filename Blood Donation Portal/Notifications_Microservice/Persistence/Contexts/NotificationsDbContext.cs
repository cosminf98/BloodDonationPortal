using Microsoft.EntityFrameworkCore;
using Notifications_Microservice.Models;
using System;

namespace Notifications_Microservice.Persistence.Contexts
{
    public class NotificationsDbContext : DbContext
    {
        public NotificationsDbContext(DbContextOptions<NotificationsDbContext> options) : base(options) { }
        public NotificationsDbContext() { }

        public DbSet<PrivateNotification> PrivateNotifications{ get; set; }
        public DbSet<PublicNotification> PublicNotifications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Setting Primary Keys
            builder.Entity<PrivateNotification>()
                .HasKey(p => p.Id);
            builder.Entity<PublicNotification>()
                .HasKey(p => p.Id);

            //Setting constraints
            builder.Entity<PrivateNotification>().Property("DonorEmail").IsRequired();
            builder.Entity<PublicNotification>().Property("BloodTypeNeeded").IsRequired().HasMaxLength(3);

            builder.Entity<PrivateNotification>().Property(n => n.CreatedAt).HasDefaultValue(DateTime.Now);
            builder.Entity<PublicNotification>().Property(n => n.CreatedAt).HasDefaultValue(DateTime.Now);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO : move connection string to appsettings.json
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Notifications;Trusted_Connection=True; Initial Catalog=NotificationsDb;Integrated Security=SSPI;");

        }
    }
}
