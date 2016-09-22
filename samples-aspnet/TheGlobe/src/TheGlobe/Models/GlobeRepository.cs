﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGlobe.Models
{
    public class GlobeRepository : IGlobeRepository
    {
        private GlobeContext _context;
        private ILogger<GlobeRepository> _logger;

        public GlobeRepository(GlobeContext context, ILogger<GlobeRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Trip> GetAllTrips()
        {
            _logger.LogInformation("Getting all Trips from the Database");

            return _context.Trips.ToList();
        }


    }
}
