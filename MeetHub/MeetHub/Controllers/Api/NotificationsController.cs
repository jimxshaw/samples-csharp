using MeetHub.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace MeetHub.Controllers.Api
{
    // Add the Authorize tag because only logged in users will get notifications.
    [Authorize]
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext _context;

        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Notification> GetNewNotifications()
        {
            string userId = User.Identity.GetUserId();

            // Get user notifications for the currently logged in user, select the 
            // actual notifications that have details of what has happened 
            // from the user notifications list then eager load the meetup & artist that 
            // this notification is referencing.
            var notifications = _context.UserNotifications
                .Where(un => un.UserId == userId)
                .Select(un => un.Notification)
                .Include(n => n.Meetup.Group)
                .ToList();

            return notifications;
        }
    }
}
