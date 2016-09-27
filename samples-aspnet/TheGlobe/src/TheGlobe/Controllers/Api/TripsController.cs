using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TheGlobe.Models;
using TheGlobe.ViewModels;

namespace TheGlobe.Controllers.Api
{
    [Route("api/trips")]
    [Authorize]
    public class TripsController : Controller
    {
        private IGlobeRepository _repository;

        public TripsController(IGlobeRepository repository)
        {
            _repository = repository;
        }

        // Our HttpGet and HttpPost attributes are blank because we specified 
        // the route attribute on the class itself and thus these two method 
        // will assume what routing pattern in that route attribute.
        [HttpGet("")]
        public IActionResult Get()
        {
            try
            {
                var trips = _repository.GetUserTripsWithStops(User.Identity.Name);

                return Ok(Mapper.Map<IEnumerable<TripViewModel>>(trips));
            }
            catch (Exception ex)
            {
                // TODO Logging.
                return BadRequest(ex);
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] TripViewModel theTrip)
        {
            if (ModelState.IsValid)
            {
                // Save to the database.
                var newTrip = Mapper.Map<Trip>(theTrip);

                newTrip.UserName = User.Identity.Name;

                _repository.AddTrip(newTrip);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"api/trips/{theTrip.Name}", Mapper.Map<TripViewModel>(newTrip));
                }
                
            }

            return BadRequest("Failed to save the trip");
        }
    }
}
