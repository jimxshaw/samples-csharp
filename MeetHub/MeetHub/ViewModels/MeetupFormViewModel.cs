
using MeetHub.Models;
using System.Collections.Generic;

namespace MeetHub.ViewModels
{
    public class MeetupFormViewModel
    {
        public string Venue { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte Category { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}