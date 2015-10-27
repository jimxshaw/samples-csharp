using System.Web.Mvc;
using SimpleBlogMVC.Infrastructure;

namespace SimpleBlogMVC.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        [Authorize(Roles = "admin")]
        // The selected tab filter will be attached to all actions
        // within the users controller. The layout now will know the
        // users tab should be selected.
        [SelectedTab("users")]
        public ActionResult Index()
        {
            return View();
            //return Content("Users!");
        }
    }
}