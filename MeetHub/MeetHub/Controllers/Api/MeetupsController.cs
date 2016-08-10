using MeetHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace MeetHub.Controllers.Api
{
    // The reason we created a separate web api controller for our Cancel a meetup action is that 
    // we'll use AJAX to update only a portion of the page, not update the whole page.
    [Authorize]
    public class MeetupsController : ApiController
    {
        private ApplicationDbContext _context;

        public MeetupsController()
        {
            _context = new ApplicationDbContext();
        }

        // We only want this Cancel action to be executed with the HttpDelete verb.
        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            // Only the user who created the meetup can cancel it.
            var userId = User.Identity.GetUserId();
            var meetup = _context.Meetups.Single(m => m.Id == id && m.GroupId == userId);
            meetup.IsCancelled = true;

            _context.SaveChanges();

            return Ok();
        }
    }
}
