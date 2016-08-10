using MeetHub.Models;
using MeetHub.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MeetHub.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            // On our index page, we make sure to only display the meetups 
            // that are not canceled.
            var upcomingMeetups = _context.Meetups
                .Include(m => m.Group)
                .Include(m => m.Category)
                .Where(m => m.DateTime > DateTime.Now && !m.IsCanceled);

            var viewModel = new MeetupsViewModel
            {
                UpcomingMeetups = upcomingMeetups,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcoming Meetups"
            };

            return View("Meetups", viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}