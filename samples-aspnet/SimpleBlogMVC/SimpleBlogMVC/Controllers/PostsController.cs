using System.Web.Mvc;

namespace SimpleBlogMVC.Controllers
{
    public class PostsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}