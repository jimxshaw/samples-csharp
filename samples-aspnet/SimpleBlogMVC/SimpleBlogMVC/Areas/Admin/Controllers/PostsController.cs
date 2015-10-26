using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleBlogMVC.Areas.Admin.Controllers
{
    // Access to the admin posts and users controllers have
    // to be limited through the use of certain attributes.
    [Authorize(Roles = "admin")]
    public class PostsController : Controller
    {
        public ActionResult Index()
        {
            return Content("Admin posts!");
        }
    }
}