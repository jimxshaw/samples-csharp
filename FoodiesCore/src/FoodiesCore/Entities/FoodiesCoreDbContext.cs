using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodiesCore.Entities
{
    public class FoodiesCoreDbContext : IdentityDbContext<User>
    {
        public DbSet<Restaurant> Restaurants { get; set; }

        public FoodiesCoreDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
