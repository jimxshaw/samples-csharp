using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MeetHub.Models
{
    public class Meetup
    {
        public int Id { get; set; }

        public bool IsCancelled { get; private set; }

        public ApplicationUser Group { get; set; }

        // The GroupId is a string and not an int is because in the 
        // ApplicationUser class, which is part of ASP.NET Identity, 
        // the id property, a key, is defined as a string.
        [Required]
        public string GroupId { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        public Category Category { get; set; }

        [Required]
        public byte CategoryId { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public string Description { get; set; }

        // We use a private setter because when we initialize this collection, we don't want to accidentally set 
        // it again with another collection. 
        public ICollection<Attendance> Attendances { get; private set; }

        public Meetup()
        {
            Attendances = new Collection<Attendance>();
        }

        public void Cancel()
        {
            IsCancelled = true;

            // We send a notification when a meetup is cancelled. We call the static factory method.
            var notification = Notification.MeetupCancelled(this);

            // Iterate over the list of attendees from our meetup's attendances collection.
            // We pass the notification from above into the .Notify method of each attendee 
            // then add it to our database context.
            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }

        public void Modify(DateTime dateTime, string venue, byte category)
        {
            // Instantiate a new Notification for this particular meetup object telling it that
            // it's being updated. This meetup's DateTime and Venue will be the notification's 
            // original DateTime and Venue. We call the static factory method.
            var notification = Notification.MeetupUpdated(this, DateTime, Venue);

            // This meetup's properties will be set with the new one passed in.
            Venue = venue;
            DateTime = dateTime;
            CategoryId = category;

            // For each attendee in the attendances collection that will attend this meetup, 
            // notify them with the new notification object.
            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }
    }
}