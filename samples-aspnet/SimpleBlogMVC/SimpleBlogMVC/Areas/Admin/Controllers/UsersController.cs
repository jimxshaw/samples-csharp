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

        public ActionResult Edit(int id)
        {
            var user = Database.Session.Load<User>(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(new UsersEdit
            {
                Username = user.Username,
                Email = user.Email
            });
        }

        [HttpPost]
        public ActionResult Edit(int id, UsersEdit form)
        {
            var user = Database.Session.Load<User>(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            if (Database.Session.Query<User>().Any(u => u.Username == form.Username && u.Id != id))
            {
                // If you find a username that's already taken in the database and it's not you then 
                // show a message.
                ModelState.AddModelError("Username", "Username must be unique");
            }

            if (!ModelState.IsValid)
            {
                // If the ModelState is invalid and any of the validation failed or any model errors were added
                // then the form is re-shown.
                return View(form);
            }

            user.Username = form.Username;
            user.Email = form.Email;
            Database.Session.Update(user);

            return RedirectToAction("Index");
        }

        public ActionResult ResetPassword(int id)
        {
            var user = Database.Session.Load<User>(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(new UsersResetPassword
            {
                Username = user.Username
            });
        }

        [HttpPost]
        public ActionResult ResetPassword(int id, UsersResetPassword form)
        {
            var user = Database.Session.Load<User>(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            // The form has a Username property that's not populated by the form but
            // by the controller. The ResetPassword GET & POST must set the Username or
            // it won't appear on the view.
            form.Username = user.Username;

            if (!ModelState.IsValid)
            {
                // If the ModelState is invalid and any of the validation failed or any model errors were added
                // then the form is re-shown.
                return View(form);
            }

            user.SetPassword(form.Password);
            Database.Session.Update(user);

            return RedirectToAction("Index");
        }
    }
}