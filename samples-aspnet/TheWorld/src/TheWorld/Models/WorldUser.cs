using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TheWorld.Models
{
    // Our WorldUser inherits from EF's IdentityUser,
    // which has a number of virtual members.
    public class WorldUser : IdentityUser
    {
        public DateTime FirstTrip { get; set; }
    }
}