using MeetHub.Models;
using MeetHub.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace MeetHub.Controllers
{
    public class MeetupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MeetupsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new MeetupFormViewModel
            {
                Categories = _context.Categories.ToList()
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(MeetupFormViewModel viewModel)
        {
            // If our view model is not valid, return the user back to the Create view with 
            // validation messages showing.
            if (!ModelState.IsValid)
            {
                // We have to re-initialize our Categories list or a null exception will be thrown.
                viewModel.Categories = _context.Categories.ToList();
                return View("Create", viewModel);
            }

            var meetup = new Meetup
            {
                GroupId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                CategoryId = viewModel.Category,
                Venue = viewModel.Venue,
                Title = viewModel.Title,
                Description = viewModel.Description
            };

            _context.Meetups.Add(meetup);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}