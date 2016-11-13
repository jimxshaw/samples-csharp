using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodiesCore.Models;

namespace FoodiesCore.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAllRestaurants();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "Texas Land and Cattle" },
                new Restaurant { Id = 1, Name = "King Buffet" },
                new Restaurant { Id = 3, Name = "Pho Noodles" }
            };
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            return _restaurants;
        }
    }
}
