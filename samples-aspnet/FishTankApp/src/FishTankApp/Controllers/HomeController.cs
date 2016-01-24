using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishTankApp.Services;
using Microsoft.AspNet.Mvc;

namespace FishTankApp.Controllers
{
    public class HomeController : Controller
    {
        private IViewModelService _viewModelService;

        public HomeController(IViewModelService viewModelService)
        {
            _viewModelService = viewModelService;
        }

        // With ASP.NET 5 MVC, the convention is to use IActionResult instead of 
        // ActionResult. You can create your own ActionResult without being tied 
        // to the ActionResult abstract base class. 
        public IActionResult Index()
        {
            ViewBag.Title = "Fish tank dashboard app";

            return View(_viewModelService.GetDashboardViewModel());
        }

        public IActionResult Feed(int foodAmount)
        {
            var model = _viewModelService.GetDashboardViewModel();

            model.LastFed = $"{DateTime.Now.Hour}:{DateTime.Now.Minute}. Amount: {foodAmount}";

            return View("Index", model);
        }
    }
}
