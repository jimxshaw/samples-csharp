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

        public ApplicationUser User { get; set; }

        public Notification Notification { get; set; }

        public bool IsRead { get; set; }
    }
}