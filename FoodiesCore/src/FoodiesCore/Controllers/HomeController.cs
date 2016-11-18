using FoodiesCore.Entities;
using FoodiesCore.Services;
using FoodiesCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FoodiesCore.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        public HomeController(IRestaurantData restraurantData, IGreeter greeter)
        {
            _restaurantData = restraurantData;
            _greeter = greeter;
        }

        public IActionResult Index()
        {
            var model = new HomePageViewModel
            {
                CurrentMessage = _greeter.GetGreeting(),
                Restaurants = _restaurantData.GetAllRestaurants()
            };

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.GetRestaurant(id);

            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RestaurantEditViewModel viewModel)
        {
            var newRestaurant = new Restaurant();
            newRestaurant.Cuisine = viewModel.Cuisine;
            newRestaurant.Name = viewModel.Name;

            newRestaurant = _restaurantData.Add(newRestaurant);

            return View("Details", newRestaurant);
        }
    }
}
