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
            // An attendance has to have a meetup. We'll never delete any meetups though, only cancel them.
            // So we'll have to turn off cascade on delete.
            modelBuilder.Entity<Attendance>()
                .HasRequired(a => a.Meetup).WithMany()
                .WillCascadeOnDelete(false);

            // Be sure to call base last.
            base.OnModelCreating(modelBuilder);
        }
    }
}