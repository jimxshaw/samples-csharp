using FoodiesCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodiesCore.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restraurantData)
        {
            _restaurantData = restraurantData;
        }

        public IActionResult Index()
        {
            var model = _restaurantData.GetAllRestaurants();

            return View(model);
        }
    }
}
