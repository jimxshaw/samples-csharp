using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheGlobe.Models
{
    public interface IGlobeRepository
    {
        IEnumerable<Trip> GetAllTrips();
        void AddTrip(Trip trip);
        void AddStop(string tripName, Stop newStop);
        Task<bool> SaveChangesAsync();
        Trip GetTripByName(string tripName);
        
    }
}