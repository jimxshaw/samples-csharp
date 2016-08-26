using MeetHub.Controllers.Api;
using MeetHub.Models;
using System;

namespace MeetHub.DTOs
{
    // NotificationDTO is simply a copy of Notification but with 
    // unneeded properties removed or changed. 
    public class NotificationDataTransferObject
    {
        public DateTime DateTime { get; set; }

        public NotificationType Type { get; set; }

        public DateTime? OriginalDateTime { get; set; }

        public string OriginalVenue { get; set; }

        public MeetupDataTransferObject Meetup { get; set; }
    }
}