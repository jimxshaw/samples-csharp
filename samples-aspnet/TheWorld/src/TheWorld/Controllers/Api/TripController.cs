using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheWorld.Models;

namespace TheWorld.Controllers.Api
{
    [Route("api/trips")]
    public class TripController : Controller
    {
        private IWorldRepository _repository;

        public TripController(IWorldRepository repository)
        {
            _repository = repository;
        }

        // By having an empty route within the parenthesis,
        // it'll default to the route placed on top of the above
        // class attribute tag.
        [HttpGet("")]
        public JsonResult Get()
        {
            var results = _repository.GetAllTripsWithStops();
            return Json(results);
        }

        [HttpPost("")]
        public JsonResult Post([FromBody]Trip newTrip)
        {
            return Json(true);
        }
    }
}
