using System.Linq;
using System.Web.Mvc;
using NHibernate.Linq;
using SimpleBlogMVC.Areas.Admin.ViewModels;
using SimpleBlogMVC.Infrastructure;
using SimpleBlogMVC.Models;

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
            return View(new UsersIndex
            {
                // Retrieves every user in the database and returns them as
                // user objects.
                Users = Database.Session.Query<User>().ToList()   
            });
            //return Content("Users!");
        }

        public ActionResult New()
        {
            return View(new UsersNew
            {

            });
        }

        [HttpPost]
        public ActionResult New(UsersNew form)
        {
            if (Database.Session.Query<User>().Any(u => u.Username == form.Username))
            {
                ModelState.AddModelError("Username", "Username must be unique");
            }

            if (!ModelState.IsValid)
            {
                return View(form);
            }

            var user = new User
            {
                Email = form.Email,
                Username = form.Username
            };

            user.SetPassword(form.Password);

            Database.Session.Save(user);

            return RedirectToAction("Index");
        }
    }
}