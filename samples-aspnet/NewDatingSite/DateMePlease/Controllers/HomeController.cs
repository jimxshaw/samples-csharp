﻿using DateMePlease.Data;
using System.Web.Mvc;

namespace DateMePlease.Controllers
{
    public class HomeController : Controller
    {
        private IDateMePleaseRepository _repository;
        public HomeController(IDateMePleaseRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var randomProfiles = _repository.GetRandomProfiles(6);

            return View(randomProfiles);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Acknowledgements()
        {
            return View();
        }
    }
}