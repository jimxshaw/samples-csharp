using System;
using System.Collections.Generic;
using System.Linq;

namespace TheWorld.Models
{
    public class WorldContextSeedData
    {
        private WorldContext _context;

        public WorldContextSeedData(WorldContext context)
        {
            _context = context;
        }
        public void EnsureSeedData()
        {
            if (!_context.Trips.Any())
            {
                // Add new data
                var usTrip = new Trip()
                {
                    Name = "US Trip",
                    Created = DateTime.Now,
                    UserName = "",
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
                    UserName = "",
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
