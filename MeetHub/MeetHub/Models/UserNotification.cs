using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetHub.Models
{
    // This is the cross table between the User and the Notification.
    public class UserNotification
    {
        // Various properties have a private setters so that they won't be arbitrarily set. 
        // For example, the UserId is a unique identifier. It shouldn't ever be 
        // set later after the object has been created.
        // By having private setters, they're akin to read-only fields and will always be in their valid states.

        // We must explicitly state the composite primary keys. As usual,
        // when we use the Key attribute we must also explicitly order of the 
        // columns. 
        [Key]
        [Column(Order = 1)]
        public string UserId { get; private set; }

        [Key]
        [Column(Order = 2)]
        public int NotificationId { get; private set; }

        public ApplicationUser User { get; private set; }

        public Notification Notification { get; private set; }

        public bool IsRead { get; private set; }

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

        public void Read()
        {
            IsRead = true;
        }
    }
}