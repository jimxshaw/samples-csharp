
using MeetHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeetHub.ViewModels
{
    public class MeetupFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public byte Category { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                // If we're dealing with a new meetup, our action will be Create but 
                // if we're dealing with an existing meetup then our action will be Update. 
                return (Id != 0) ? "Update" : "Create";
            }
        }

        public DateTime GetDateTime()
        {
            return DateTime.Parse($"{Date} {Time}");
        }
    }
}