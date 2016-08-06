using System.Collections.Generic;
using MeetHub.Models;

namespace MeetHub.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Meetup> UpcomingMeetups { get; set; }
        public bool ShowActions { get; set; }
    }
}