﻿using System.Data.Entity;

namespace OdeToFood.Models
{
    public class OdeToFoodDb : DbContext
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReview> Reviews { get; set; }
    }
}