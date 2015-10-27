using System.Web.Mvc;
using SimpleBlogMVC.Infrastructure;

namespace SimpleBlogMVC.Areas.Admin.Controllers
{
    // Access to the admin posts and users controllers have
    // to be limited through the use of certain attributes.
    [Authorize(Roles = "admin")]
    [SelectedTab("posts")]
    public class PostsController : Controller
    {
        public ActionResult Index()
        {
            return View();
            //return Content("Admin posts!");
        }
    }
}