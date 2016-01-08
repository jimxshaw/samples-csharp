using System;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Storage;

namespace TheWorld.Models
{
    // To store our own entities, we have to change DbContext into
    // an IdentityDbContext. 
    public class WorldContext : IdentityDbContext<WorldUser>
    {
        public WorldContext()
        {
            // This'll create the database itself and if any migrations
            // need to be executed, it'll execute at the same time.
            Database.EnsureCreated();
        }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<Stop> Stops { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = Startup.Configuration["Data:WorldContextConnection"];

            optionsBuilder.UseSqlServer(connString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}