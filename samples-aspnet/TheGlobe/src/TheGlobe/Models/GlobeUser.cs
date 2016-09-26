using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TheGlobe.Models
{
    public class GlobeUser : IdentityUser
    {
        public DateTime FirstTrip { get; set; }
    }
}