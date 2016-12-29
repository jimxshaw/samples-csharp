using System.Collections.Generic;
using OdeToFood.Models;

namespace OdeToFood.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OdeToFood.Models.OdeToFoodDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OdeToFood.Models.OdeToFoodDb context)
        {
            context.Restaurants.AddOrUpdate(r => r.Name, 
                new Restaurant { Name = "Freebird", City = "Dallas", Country = "USA" },
                new Restaurant { Name = "The Lazy Gator", City = "Miami", Country = "USA"},
                new Restaurant { Name = "Chairman's Palace", City = "Beijing", Country = "China"},
                new Restaurant
                {
                    Name = "Star of Munich",
                    City = "Munich",
                    Country = "Germany",
                    Reviews = new List<RestaurantReview>
                    {
                        new RestaurantReview { Rating = 8, Body = "Large portions!", ReviewerName = "Dieter Hans" }
                    }
                });
        }
    }
}
