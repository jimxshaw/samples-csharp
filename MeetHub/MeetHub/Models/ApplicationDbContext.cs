using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace MeetHub.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Meetup> Meetups { get; set; }
        public DbSet<Category> Categories { get; set; }
        // An attendance is contains a meetup and an application user. It's essentially 
        // the cross table between those two objects. 
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Following> Followings { get; set; }

        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // An attendance has to have a meetup. A meetup has many attendances. 
            // We'll never delete any meetups though, only cancel them.
            // So we'll have to turn off cascade on delete.
            modelBuilder.Entity<Attendance>()
                .HasRequired(a => a.Meetup)
                .WithMany(m => m.Attendances)
                .WillCascadeOnDelete(false);

            // An application user has many followers. Each follower has a required followee.
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Followers)
                .WithRequired(f => f.Followee)
                .WillCascadeOnDelete(false);

            // An application user has many followees. Each followee has a required follower.
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Followees)
                .WithRequired(f => f.Follower)
                .WillCascadeOnDelete(false);

            // Each UserNotification has only 1 user and 1 user can have many UserNotifications.
            modelBuilder.Entity<UserNotification>()
                .HasRequired(n => n.User)
                .WithMany(u => u.UserNotifications)
                .WillCascadeOnDelete(false);

            // Be sure to call base last.
            base.OnModelCreating(modelBuilder);
        }
    }
}