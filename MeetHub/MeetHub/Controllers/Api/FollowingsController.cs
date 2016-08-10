using System.Linq;
using System.Web.Http;
using MeetHub.DTOs;
using MeetHub.Models;
using Microsoft.AspNet.Identity;

namespace MeetHub.Controllers.Api
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDataTransferObject dto)
        {
            var userIdString = User.Identity.GetUserId();

            if (_context.Followings.Any(f => f.FolloweeId == userIdString && f.FolloweeId == dto.FolloweeId))
            {
                return BadRequest("Following already exists.");
            }

            var following = new Following()
            {
                FollowerId = userIdString,
                FolloweeId = dto.FolloweeId
            };

            _context.Followings.Add(following);
            _context.SaveChanges();

            return Ok();
        }
    }
}
