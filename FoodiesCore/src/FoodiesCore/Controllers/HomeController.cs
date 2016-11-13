using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodiesCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodiesCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new Restaurant { Id = 1, Name = "Jim's Sushi Shop" };

            return View(model);
        }
    }
}
