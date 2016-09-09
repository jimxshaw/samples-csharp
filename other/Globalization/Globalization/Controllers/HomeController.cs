using Globalization.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Globalization.Controllers
{
    public class HomeController : Controller
    {
        private static List<Demo> list = new List<Demo>();

        public ActionResult Index()
        {
            return View(list);
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

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Demo model)
        {
            if (ModelState.IsValid)
            {
                list.Add(model);

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}