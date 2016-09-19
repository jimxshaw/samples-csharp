using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TheGlobe.Services;
using TheGlobe.ViewModels;

namespace TheGlobe.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private IConfigurationRoot _config;

        public AppController(IMailService mailService, IConfigurationRoot config)
        {
            _mailService = mailService;
            _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {   
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel viewModel)
        {
            _mailService.SendMail(_config["MailSettings:ToAddress"], viewModel.Email, "From The Globe", viewModel.Message);
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
