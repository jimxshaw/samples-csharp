using System.Collections.Generic;
using System.Linq;
using FoodiesCore.Entities;

namespace FoodiesCore.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAllRestaurants();
        Restaurant GetRestaurant(int id);
        Restaurant AddRestaurant(Restaurant newRestaurant);
        void Commit();
    }

    public class SqlRestaurantData : IRestaurantData
    {
        private FoodiesCoreDbContext _context;

        public SqlRestaurantData(FoodiesCoreDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            return _context.Restaurants;
        }

        public Restaurant GetRestaurant(int id)
        {
            return _context.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public Restaurant AddRestaurant(Restaurant newRestaurant)
        {
            _context.Add(newRestaurant);
            _context.SaveChanges();

            return newRestaurant;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
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

        public Restaurant AddRestaurant(Restaurant newRestaurant)
        {
            newRestaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(newRestaurant);

            return newRestaurant;
        }

        public void Commit()
        {
            // In memory data changes are not transactional. If a change is made, 
            // that change will be already committed.
        }
    }
}
