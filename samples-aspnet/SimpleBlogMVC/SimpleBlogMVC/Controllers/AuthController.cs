using System.Web.Mvc;
using System.Web.Security;
using SimpleBlogMVC.ViewModels;

namespace SimpleBlogMVC.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToRoute("Home");
        }

        // Get action is by default
        public ActionResult Login()
        {
            return View(new AuthLogin
            {
                // Test = "This is the test value set in my controller!"
            });
            // return Content("Login");
        }

        [HttpPost]
        public ActionResult Login(AuthLogin form, string returnUrl)
        {
            // form.Test = "This is the value set in my post action";

            // Even though we put [Required] on the Auth ViewModel properties,
            // we put the below code to perform some action during validation.
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            //if (form.Username != "hello")
            //{
            //    ModelState.AddModelError("Username", "Username or password isn't valid");
            //    return View(form);
            //}

            FormsAuthentication.SetAuthCookie(form.Username, true);

            if (!string.IsNullOrWhiteSpace(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToRoute("Home");

            // return Content("The Form is valid");
            // return Content("Hey " + form.Username + ", how are you?");
        }
    }
}