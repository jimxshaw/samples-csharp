using MeetHub.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
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

            // Use the .Include method for eager loading.
            // Capture all users who planned to attend the cancelled meetup.
            var meetup = _context.Meetups
                .Include(m => m.Attendances.Select(a => a.Attendee))
                .Single(m => m.Id == id && m.GroupId == userId);

            // We add an if conditional to check if the selected meetup is already cancelled.
            // If yes then we break out and ignore the cancel request. 
            if (meetup.IsCancelled)
            {
                return NotFound();
            }

            meetup.IsCancelled = true;

            // We send a notification when a meetup is cancelled.
            var notification = new Notification(NotificationType.MeetupCancelled, meetup);

            // Iterate over the list of attendees from our meetup's attendances collection.
            // We pass the notification from above into the .Notify method of each attendee 
            // then add it to our database context.
            foreach (var attendee in meetup.Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
