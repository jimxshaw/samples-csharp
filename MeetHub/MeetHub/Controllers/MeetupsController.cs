using MeetHub.Models;
using MeetHub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
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
            var meetup = new Meetup
            {
                GroupId = User.Identity.GetUserId(),
                DateTime = DateTime.Parse(string.Format("{0} {1}", viewModel.Date, viewModel.Time)),
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