using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleBlogMVC.ViewModels;

namespace SimpleBlogMVC.Controllers
{
    public class AuthController : Controller
    {
        // Get action is by default
        public ActionResult Login()
        {
            return View(new AuthLogin
            {
                // Test = "This is the test value set in my controller!"
            });
            //return Content("Login");
        }

        [HttpPost]
        public ActionResult Login(AuthLogin form)
        {
            // form.Test = "This is the value set in my post action";
            return View(form);
            // return Content("Hey " + form.Username + ", how are you?");
        }
    }
}