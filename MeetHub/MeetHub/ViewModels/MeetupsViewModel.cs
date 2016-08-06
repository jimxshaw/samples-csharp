using MeetHub.Models;
using System.Collections.Generic;

namespace MeetHub.ViewModels
{
    public class MeetupsViewModel
    {
        public IEnumerable<Meetup> UpcomingMeetups { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
    }
}