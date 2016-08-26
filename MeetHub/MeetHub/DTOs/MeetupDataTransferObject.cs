using MeetHub.Controllers.Api;
using System;

namespace MeetHub.DTOs
{
    // MeetupDTO is simply a copy of Meetup but with 
    // unneeded properties removed or changed.
    public class MeetupDataTransferObject
    {
        // MeetupDTO still needs the Id property because we need it when 
        // we create the detail page of a particular Meetup. 
        public int Id { get; set; }

        public bool IsCancelled { get; set; }

        // Remember, Group used to be of type ApplicationUser and that exposed 
        // many meta-data properties such as PasswordHash, SecurityStamp or 
        // other sensitive items to the client. We instead change Group's type 
        // to UserDTO as to take control of exactly what to expose to the client.
        public UserDataTransferObject Group { get; set; }

        public DateTime DateTime { get; set; }

        public string Venue { get; set; }

        public CategoryDataTransferObject Category { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

    }
}