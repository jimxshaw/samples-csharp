using Foodies.Models;
using System.Web.Mvc;

namespace Foodies.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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