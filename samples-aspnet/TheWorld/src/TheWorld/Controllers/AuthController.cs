using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using TheWorld.Models;
using TheWorld.ViewModels;

namespace TheWorld.Controllers
{
    // Our controller inherits from Controller so that
    // .NET knows it's an MVC controller.
    public class AuthController : Controller
    {
        private SignInManager<WorldUser> _signInManager;
        
        public AuthController(SignInManager<WorldUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Trips", "App");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                // Since our sign in manager uses an async method, we must add the await
                // keyword in front, add async keyword to the signature and wrap the return
                // with a Task object.
                var signInResult = await _signInManager.PasswordSignInAsync(vm.Username,
                                                                        vm.Password,
                                                                        true, false);

                if (signInResult.Succeeded)
                {
                    // When we redirect, we have a query string call ReturnUrl in the navbar.
                    // It's passed to us with the login redirction.
                    // We add the following If-Else because in the future if we support 
                    // the authorize attribute on different actions, this would redirect to
                    // where we attempted to go. e.g. account page, change profile page....
                    if (string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return RedirectToAction("Trips", "App");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    // We're adding this model state so that when it drops down to the view
                    // it'll get shown to the user and the user will attempt sign in again.
                    ModelState.AddModelError("", "Username or password incorrect");
                }

            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                // This gets rid of the cookie collection so
                // that the user is signed out.
                await _signInManager.SignOutAsync();
            }

            return RedirectToAction("Index", "App");
        } 
    }
}
