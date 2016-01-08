using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace TheWorld.Models
{
    public class WorldContextSeedData
    {
        private WorldContext _context;
        private UserManager<WorldUser> _userManager;

        public WorldContextSeedData(WorldContext context, UserManager<WorldUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task EnsureSeedDataAsync()
        {
            if (await _userManager.FindByEmailAsync("han.solo@theworld.com") == null)
            {
                // Add the user
                var newUser = new WorldUser()
                {
                    UserName = "hansolo",
                    Email = "han.solo@theworld.com"
                };

                await _userManager.CreateAsync(newUser, "P@ssw0rd!");
            }

            if (!_context.Trips.Any())
            {
                // Add new data
                var usTrip = new Trip()
                {
                    Name = "US Trip",
                    Created = DateTime.Now,
                    UserName = "hansolo",
                    Stops = new List<Stop>()
                    {
                        new Stop() { Name = "Little Rock, AR", Arrival = new DateTime(2015, 9, 12), Latitude = 34.7361, Longitude = 92.3311, Order = 0 },
                        new Stop() { Name = "Nashville, TN", Arrival = new DateTime(2015, 9, 13), Latitude = 36.1667, Longitude = 86.7833, Order = 1 },
                        new Stop() { Name = "Akron, OH", Arrival = new DateTime(2015, 9, 14), Latitude = 41.0731, Longitude = 81.5178, Order = 2 }
                    }
                };

                _context.Trips.Add(usTrip);
                _context.Stops.AddRange(usTrip.Stops);

                var worldTrip = new Trip()
                {
                    Name = "World Trip",
                    Created = DateTime.Now,
                    UserName = "hansolo",
                    Stops = new List<Stop>()
                    {
                        new Stop() { Name = "London, England", Arrival = new DateTime(2015, 12, 1), Latitude = 51.5072, Longitude = 0.1275, Order = 0 },
                        new Stop() { Name = "Paris, France", Arrival = new DateTime(2015, 12, 4), Latitude = 48.8567, Longitude = 2.3508, Order = 1 }
                    }
                };

                _context.Trips.Add(worldTrip);
                _context.Stops.AddRange(worldTrip.Stops);

                _context.SaveChanges();
            }
        }
    }
}
