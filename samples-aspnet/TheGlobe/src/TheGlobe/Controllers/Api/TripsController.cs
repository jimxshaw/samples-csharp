using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGlobe.Models;
using TheGlobe.ViewModels;

namespace TheGlobe.Controllers.Api
{
    [Route("api/trips")]
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

            return Ok(_repository.GetAllTrips());
        }

        [HttpPost("")]
        public IActionResult Post([FromBody] TripViewModel theTrip)
        {
            if (ModelState.IsValid)
            {
                // Save to the database.

                return Created($"api/trips/{theTrip.Name}", theTrip);
            }

            return BadRequest(ModelState);
        }
    }
}
