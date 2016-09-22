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

        public GlobeRepository(GlobeContext context)
        {
            _context = context;
        }

        public IEnumerable<Trip> GetAllTrips()
        {
            return _context.Trips.ToList();
        }


    }
}
