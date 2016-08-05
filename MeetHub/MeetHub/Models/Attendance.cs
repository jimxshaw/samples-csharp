using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetHub.Models
{
    public class Attendance
    {
        public Meetup Meetup { get; set; }
        public ApplicationUser Attendee { get; set; }

        // Foreign key constraints to this many-to-many relationship. 
        // The composite key of a MeetupId plus an AttendeeId represents a unique 
        // Attendance object. A composite key also requires the column order to be specified.
        [Key]
        [Column(Order = 1)]
        public int MeetupId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string AttendeeId { get; set; }
    }
}