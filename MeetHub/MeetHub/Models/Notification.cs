using System;
using System.ComponentModel.DataAnnotations;

namespace MeetHub.Models
{
    public class Notification
    {
        // Various properties have a private setters so that they won't be arbitrarily set. 
        // For example, a Notification's Id is its unique identifier. It shouldn't ever be 
        // set later after the object has been created.
        // By having private setters, they're akin to read-only fields and will always be in their valid states. 
        public int Id { get; private set; }

        public DateTime DateTime { get; private set; }

        public NotificationType Type { get; private set; }

        public DateTime? OriginalDateTime { get; set; }

        public string OriginalVenue { get; set; }

        [Required]
        public Meetup Meetup { get; private set; }

        protected Notification()
        {
        }

        public Notification(NotificationType type, Meetup meetup)
        {
            if (meetup == null)
            {
                throw new ArgumentNullException("meetup");
            }

            Type = type;
            Meetup = meetup;
            DateTime = DateTime.Now;
        }
    }
}