using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TheGlobe.Models;
using TheGlobe.Services;
using TheGlobe.ViewModels;

namespace TheGlobe.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private IConfigurationRoot _config;
        private IGlobeRepository _repository;

        public AppController(IMailService mailService, IConfigurationRoot config, IGlobeRepository repository)
        {
            _mailService = mailService;
            _config = config;
            _repository = repository;
        }

        public IActionResult Index()
        {
            var data = _repository.GetAllTrips();

            return View(data);
        }

        public IActionResult Contact()
        {   
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel viewModel)
        {
            if (viewModel.Email.Contains("fake.org"))
            {
                ModelState.AddModelError("Email", "We don't support fake.org addresses");
            }

            if (ModelState.IsValid)
            {
                _mailService.SendMail(_config["MailSettings:ToAddress"], viewModel.Email, "From The Globe",
                    viewModel.Message);

                // Clear the form fields after the form is submitted.
                ModelState.Clear();
                // Displays a message after the form is submitted.
                ViewBag.UserMessage = "Message Sent";
            }

            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
