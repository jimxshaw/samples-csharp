using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FoodiesCore.Entities
{
    public class FoodiesCoreDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }

        public FoodiesCoreDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
