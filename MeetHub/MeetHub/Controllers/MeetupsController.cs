using MeetHub.Models;
using MeetHub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
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
        public ActionResult Attending()
        {
            // This line has to be assigned to a variable as LINQ won't recognize it.
            var userId = User.Identity.GetUserId();
            var meetups = _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Meetup)
                .Include(c => c.Category)
                .Include(g => g.Group)
                .ToList();

            var viewModel = new MeetupsViewModel()
            {
                UpcomingMeetups = meetups,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Meetups I'm attending"
            };

            return View("Meetups", viewModel);
        }

        [Authorize]
        public ActionResult Mine()
        {
            // Find all of my meetups but only those that are in the future and are not cancelled. 
            var userId = User.Identity.GetUserId();
            var meetups = _context.Meetups
                                    .Where(m => m.GroupId == userId && m.DateTime > DateTime.Now && !m.IsCancelled)
                                    .Include(m => m.Category)
                                    .ToList();

            return View(meetups);
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new MeetupFormViewModel
            {
                Heading = "Add a Meetup",
                Categories = _context.Categories.ToList()
            };

            return View("MeetupForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken] // This is to prevent Cross-site Request Forgery (CSRF) attacks.
        public ActionResult Create(MeetupFormViewModel viewModel)
        {
            // If our view model is not valid, return the user back to the Create view with 
            // validation messages showing.
            if (!ModelState.IsValid)
            {
                // We have to re-initialize our Categories list or a null exception will be thrown.
                viewModel.Categories = _context.Categories.ToList();
                return View("MeetupForm", viewModel);
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
            return RedirectToAction("Mine", "Meetups");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            // We cannot allow anyone to edit any meetup. The meetup's group id must match 
            // the id of the currently logged in user id. 
            var userId = User.Identity.GetUserId();
            var meetup = _context.Meetups.Single(m => m.Id == id && userId == m.GroupId);

            var viewModel = new MeetupFormViewModel
            {
                Id = meetup.Id,
                Heading = "Edit this Meetup",
                Categories = _context.Categories.ToList(),
                Date = meetup.DateTime.ToString("MMM d yyyy"),
                Time = meetup.DateTime.ToString("HH:mm"),
                Title = meetup.Title,
                Venue = meetup.Venue,
                Description = meetup.Description
            };

            return View("MeetupForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken] // This is to prevent Cross-site Request Forgery (CSRF) attacks.
        public ActionResult Update(MeetupFormViewModel viewModel)
        {
            // If our view model is not valid, return the user back to the Create view with 
            // validation messages showing.
            if (!ModelState.IsValid)
            {
                // We have to re-initialize our Categories list or a null exception will be thrown.
                viewModel.Categories = _context.Categories.ToList();
                return View("MeetupForm", viewModel);
            }

            var userId = User.Identity.GetUserId();
            var meetup = _context.Meetups.Single(m => m.Id == viewModel.Id && m.GroupId == userId);

            meetup.Title = viewModel.Title;
            meetup.Venue = viewModel.Venue;
            meetup.DateTime = viewModel.GetDateTime();
            meetup.Description = viewModel.Description;
            meetup.CategoryId = viewModel.Category;

            _context.SaveChanges();
            return RedirectToAction("Mine", "Meetups");
        }

    }
}