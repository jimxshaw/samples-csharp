using System.Collections.Generic;

namespace TheGlobe.Models
{
    public interface IGlobeRepository
    {
        IEnumerable<Trip> GetAllTrips();
    }
}