using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodiesCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FoodiesCore.Controllers
{
    public class AccountController : Controller 
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Register(RegisterUserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                
            }

            return View();
        }
    }
}
