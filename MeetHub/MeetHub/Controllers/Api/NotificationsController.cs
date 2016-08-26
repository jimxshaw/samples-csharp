using AutoMapper;
using MeetHub.DTOs;
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

        // We return a collection of NotificationDTO instead of simply Notification in order 
        // to tailor the returned data to exactly what we want. Otherwise, we'd get so much 
        // meta-data such as PasswordHash, SecurityStamp etc. or other sensitive info we 
        // don't want to expose to the client.  
        public IEnumerable<NotificationDataTransferObject> GetNewNotifications()
        {
            string userId = User.Identity.GetUserId();

            // Get user notifications for the currently logged in user, select the 
            // actual notifications, which haven't been read, that have details of what happened 
            // from the user notifications list then eager load the meetup & artist that 
            // this notification is referencing.
            var notifications = _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .Select(un => un.Notification)
                .Include(n => n.Meetup.Group)
                .ToList();

            // Before asking AutoMapper to map a source type to the target type, we have to 
            // tell it a mapping between the two types. Those mappings take place in the 
            // MappingProfile class in MeetHub\App_Start folder.
            // In our return statement, we're not actually calling the Map method. We're simply 
            // passing a reference to that method in the Mapper class, which is part of AutoMapper. 
            return notifications.Select(Mapper.Map<Notification, NotificationDataTransferObject>);
        }
    }
}
