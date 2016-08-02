using MeetHub.Models;
using MeetHub.ViewModels;
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
    }
}