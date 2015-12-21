using Microsoft.AspNet.Mvc;
using System;
using System.Linq;
using TheWorld.Models;
using TheWorld.Services;
using TheWorld.ViewModels;

namespace TheWorld.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private WorldContext _context;

        public AppController(IMailService service, WorldContext context)
        {
            _mailService = service;
            _context = context;
        }

        public IActionResult Index()
        {
            var trips = _context.Trips.OrderBy(t => t.Name).ToList();

            return View(trips);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            // Despite model validation on the view, validation within the action is
            // still necessary. When the form is submitted and this data is posted to us
            // it re-confirms that it's still valid so that bad data wouldn't be saved to
            // the database, for example.
            if (ModelState.IsValid)
            {
                var email = Startup.Configuration["AppSettings:SiteEmailAddress"];

                if (string.IsNullOrWhiteSpace(email))
                {
                    ModelState.AddModelError("", "Could not send email, configuration issue");
                }

                if (_mailService.SendMail(email, // to
                    email, // from
                    $"Contact Page from {model.Name} ({model.Email})", // submit
                    model.Message)) // body
                {
                    // If the form is submitted then clear the form.
                    ModelState.Clear();

                    ViewBag.Message = "Mail sent. Thanks!";
                }
            }

            return View();
        }
    }
}