using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APM.WebAPI.Controllers
{
    // HomeController inherits from Controller and not
    // ApiController. It's used to display a home page.
    // In most cases a web api service does not need a 
    // user interface and you could delete this controller 
    // and associated home page. 
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
