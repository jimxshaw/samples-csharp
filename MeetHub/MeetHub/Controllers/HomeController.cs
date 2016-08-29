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

        // Index has the search term query as null by default. When the user submits a search 
        // then the Index will filter by that search term query, if applicable.
        public ActionResult Index(string query = null)
        {
            // On our index page, we make sure to only display the meetups 
            // that are not cancelled.
            var upcomingMeetups = _context.Meetups
                .Include(m => m.Group)
                .Include(m => m.Category)
                .Where(m => m.DateTime > DateTime.Now && !m.IsCancelled);

            if (!string.IsNullOrWhiteSpace(query))
            {
                // If our search term query is not null, we search through the group's name, 
                // the meetup's category, title and description for that query.
                upcomingMeetups = upcomingMeetups.Where(m =>
                    m.Group.Name.Contains(query) ||
                    m.Category.Name.Contains(query) ||
                    m.Title.Contains(query) ||
                    m.Description.Contains(query));
            }

            var viewModel = new MeetupsViewModel
            {
                UpcomingMeetups = upcomingMeetups,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcoming Meetups",
                SearchTerm = query
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