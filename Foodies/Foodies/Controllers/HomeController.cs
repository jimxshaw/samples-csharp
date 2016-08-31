﻿using Foodies.Models;
using System.Web.Mvc;

namespace Foodies.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            var controller = RouteData.Values["controller"];
            var action = RouteData.Values["action"];
            var id = RouteData.Values["id"];

            var message = $"{controller}::{action} {id}";

            ViewBag.Message = message;

            return View();
        }

        public ActionResult About()
        {
            var model = new AboutModel();
            model.Name = "James";
            model.Location = "Texas, USA";

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}