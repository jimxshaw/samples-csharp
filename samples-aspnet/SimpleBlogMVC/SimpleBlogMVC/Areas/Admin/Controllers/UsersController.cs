using System.Web.Mvc;

namespace SimpleBlogMVC.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Index()
        {
            return Content("Users!");
        }
    }
}