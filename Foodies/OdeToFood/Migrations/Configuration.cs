using OdeToFood.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using WebMatrix.WebData;

namespace OdeToFood.Migrations
{
    using System.Data.Entity.Migrations;

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
                new Restaurant { Name = "The Lazy Gator", City = "Miami", Country = "USA" },
                new Restaurant { Name = "Chairman's Palace", City = "Beijing", Country = "China" },
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

            for (int i = 0; i < 1000; i++)
            {
                context.Restaurants.AddOrUpdate(r => r.Name, new Restaurant { Name = i.ToString(), City = "Gilead", Country = "Midworld" });
            }

            SeedMembership();
        }

        private void SeedMembership()
        {
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);

            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }

            if (membership.GetUser("testuser123@gmail.com", false) == null)
            {
                membership.CreateUserAndAccount("testuser123@gmail.com", "Password123!");
            }

            if (!roles.GetRolesForUser("testuser123@gmail.com").Contains("Admin"))
            {
                roles.AddUsersToRoles(new[] { "testuser123@gmail.com" }, new[] { "admin" });
            }
        }
    }
}
