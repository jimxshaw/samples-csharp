using System;
using System.ComponentModel.DataAnnotations;

namespace MeetHub.Models
{
    public class Meetup
    {
        public int Id { get; set; }

        [Required]
        public ApplicationUser Group { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public string Description { get; set; }


    }
}