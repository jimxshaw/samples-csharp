using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheGlobe.Models
{
    public interface IGlobeRepository
    {
        IEnumerable<Trip> GetAllTrips();
        IEnumerable<Trip> GetUserTripsWithStops(string name);
        void AddTrip(Trip trip);
        void AddStop(string tripName, Stop newStop, string userName);
        Task<bool> SaveChangesAsync();
        Trip GetTripByName(string tripName, string userName);

        
    }
}