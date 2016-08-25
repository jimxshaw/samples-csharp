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
        // Notification has essentially become an immutable object. It makes sense because a notification isn't
        // something the user will change. It's for the internals of the system. Hence, why we make sure nowhere 
        // do we modify any of the class's properties.  
        public int Id { get; private set; }

        public DateTime DateTime { get; private set; }

        public NotificationType Type { get; private set; }

        public DateTime? OriginalDateTime { get; private set; }

        public string OriginalVenue { get; private set; }

        [Required]
        public Meetup Meetup { get; private set; }

        protected Notification()
        {
        }

        private Notification(NotificationType type, Meetup meetup)
        {
            if (meetup == null)
            {
                throw new ArgumentNullException("meetup");
            }

            Type = type;
            Meetup = meetup;
            DateTime = DateTime.Now;
        }

        // These a static methods utilize the factory pattern. The purpose of using a factory pattern 
        // is to prevent objects from being created in an invalid state. For example, a likely invalid 
        // state scenario would be instantiating a Notification but forgetting to set OriginalDateTime 
        //  or OriginalVenue. 
        // The first factory method is responsible for creating a Notification for a 
        // meetup that was just created by calling the private constructor. Other factory methods below 
        // are created for the other notification types. 
        public static Notification MeetupCreated(Meetup meetup)
        {
            return new Notification(NotificationType.MeetupCreated, meetup);
        }

        public static Notification MeetupUpdated(Meetup newMeetup, DateTime originalDateTime, string originalVenue)
        {
            var notification = new Notification(NotificationType.MeetupUpdated, newMeetup);
            // Be sure that OriginalDateTime and OriginalVenue properties have private setters to prevent them 
            // from being changed. They can only be changed when the right factory method is called. 
            notification.OriginalDateTime = originalDateTime;
            notification.OriginalVenue = originalVenue;

            return notification;
        }

        public static Notification MeetupCancelled(Meetup meetup)
        {
            return new Notification(NotificationType.MeetupCancelled, meetup);
        }
    }
}