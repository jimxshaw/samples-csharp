using System.Web.Mvc;

namespace MeetHub.Controllers
{
    public class MeetupsController : Controller
    {
        // GET: Meetups
        public ActionResult Create()
        {
            return View();
        }
    }
}