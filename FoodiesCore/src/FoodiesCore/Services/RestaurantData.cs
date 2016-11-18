using System.Collections.Generic;
using System.Linq;
using FoodiesCore.Entities;

namespace FoodiesCore.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAllRestaurants();
        Restaurant GetRestaurant(int id);
        Restaurant Add(Restaurant newRestaurant);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        private static List<Restaurant> _restaurants;

        static InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "Texas Land and Cattle" },
                new Restaurant { Id = 2, Name = "King Buffet" },
                new Restaurant { Id = 3, Name = "Pho Noodles" }
            };
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            return _restaurants;
        }

        public Restaurant GetRestaurant(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(newRestaurant);

            return newRestaurant;
        }
    }
}
