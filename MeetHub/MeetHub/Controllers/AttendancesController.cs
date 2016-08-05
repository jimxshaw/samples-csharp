﻿using MeetHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace MeetHub.Controllers
{
    // Add the authorize tag as this entire class will only allowed to be 
    // accessed up signed in users. 
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        // Add the HttpPost because this method will only be called from a post request.
        // Also, ASP.NET web api by default does not look for scattered parameters in 
        // the request's body like our int meetupId. It expects them to be in the url. 
        // We must literally specify that our parameter will come from the request body 
        // by using a FromBody attribute.   
        [HttpPost]
        public IHttpActionResult Attend([FromBody] int meetupId)
        {
            // The user id is not a parameter to this method due to 
            // security reasons. The user id will instead be retrieved from 
            // the current logged in user.

            // If an attendance object exists which already contains the current logged in user and the passed in meetup id then 
            // we ignore it. We wouldn't want to add a duplicate attendance object.
            string userIdString = User.Identity.GetUserId();

            if (_context.Attendances.Any(a => a.AttendeeId == userIdString && a.MeetupId == meetupId))
            {
                return BadRequest("The attendance object already exists.");
            }

            var attendance = new Attendance()
            {
                MeetupId = meetupId,
                AttendeeId = userIdString
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }


    }
}
