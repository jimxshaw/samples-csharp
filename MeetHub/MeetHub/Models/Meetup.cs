using System;
using System.ComponentModel.DataAnnotations;

namespace MeetHub.Models
{
    public class Meetup
    {
        public int Id { get; set; }

        public bool IsCanceled { get; set; }

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


    }
}