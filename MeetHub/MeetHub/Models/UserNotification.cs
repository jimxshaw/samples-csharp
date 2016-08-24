using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetHub.Models
{
    // This is the cross table between the User and the Notification.
    public class UserNotification
    {
        // We must explicitly state the composite primary keys. As usual,
        // when we use the Key attribute we must also explicitly order of the 
        // columns. 
        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int NotificationId { get; set; }

        // User and Notification have private setters so that they won't be arbitrarily set. They'll
        // always be in their valid states. 
        public ApplicationUser User { get; private set; }

        public Notification Notification { get; private set; }

        public bool IsRead { get; set; }

        // Our default constructor has to be created in order for Entity Framework to call it at run time, as it cannot 
        // call the custom constructor. Everyone else has to use the custom constructor though because we 
        // place the protected accessor on the default constructor. 
        protected UserNotification()
        {
        }

        public UserNotification(ApplicationUser user, Notification notification)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (notification == null)
            {
                throw new ArgumentNullException("notification");
            }
            User = user;
            Notification = notification;
        }
    }
}