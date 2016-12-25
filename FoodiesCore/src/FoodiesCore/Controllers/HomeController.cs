using FoodiesCore.Entities;
using FoodiesCore.Services;
using FoodiesCore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodiesCore.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        public HomeController(IRestaurantData restraurantData, IGreeter greeter)
        {
            _restaurantData = restraurantData;
            _greeter = greeter;
        }

        [AllowAnonymous]
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
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var newRestaurant = new Restaurant();
                newRestaurant.Cuisine = viewModel.Cuisine;
                newRestaurant.Name = viewModel.Name;

                newRestaurant = _restaurantData.AddRestaurant(newRestaurant);

                // Call commit so that Entity Framework will execute an insert statement.
                _restaurantData.Commit();

                return RedirectToAction("Details", new {id = newRestaurant.Id});
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _restaurantData.GetRestaurant(id);

            if (model == null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, RestaurantEditViewModel viewModel)
        {
            var restaurant = _restaurantData.GetRestaurant(id);

            if (ModelState.IsValid)
            {
                restaurant.Cuisine = viewModel.Cuisine;
                restaurant.Name = viewModel.Name;

                // Entity Framework knows which particular restaurant, by the id, had its data
                // updated. The commit method is called so that Entity Framework can reconcile
                // the data changes with the database. 
                _restaurantData.Commit();

                return RedirectToAction("Details", new { id = restaurant.Id });
            }

            return View(restaurant);
        }
    }
}
