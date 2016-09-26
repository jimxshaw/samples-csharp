using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGlobe.Models;
using TheGlobe.Services;
using TheGlobe.ViewModels;

namespace TheGlobe.Controllers.Api
{
    [Route("/api/trips/{tripName}/stops")]
    public class StopsController : Controller
    {
        private GeoCoordinatesService _coordinatesService;
        private ILogger<StopsController> _logger;
        private IGlobeRepository _repository;

        public StopsController(IGlobeRepository repository, 
            ILogger<StopsController> logger,
            GeoCoordinatesService coordinatesService)
        {
            _repository = repository;
            _logger = logger;
            _coordinatesService = coordinatesService;
        }

        [HttpGet("")]
        public IActionResult Get(string tripName)
        {
            try
            {
                var trip = _repository.GetTripByName(tripName);

                // What's actually returned from the database is a collection of raw model class of Stop but we don't want to return 
                // the raw model. We want to return a collection of StopViewModel instead. To do this we use AutoMapper to map 
                // the collection of Stop to a collection of StopViewModel first and then we return that instead.  
                return Ok(Mapper.Map<IEnumerable<StopViewModel>>(trip.Stops.OrderBy(s => s.Order).ToList()));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get stops: {ex}");
            }

            return BadRequest("Failed to get stops");
        }

        [HttpPost("")]
        public async Task<IActionResult> Post(string tripName, [FromBody] StopViewModel viewModel)
        {
            try
            {
                // If the view model is valid
                if (ModelState.IsValid)
                {
                    var newStop = Mapper.Map<Stop>(viewModel);

                    // Lookup the Geocode
                    var result = await _coordinatesService.GetCoordinatesAsync(newStop.Name);

                    if (!result.Successful)
                    {
                        _logger.LogError(result.Message);
                    }
                    else
                    {
                        newStop.Latitude = result.Latitude;
                        newStop.Longitude = result.Longitude;

                        // Save to the database
                        _repository.AddStop(tripName, newStop);

                        if (await _repository.SaveChangesAsync())
                        {
                            // The call to Created is the result of a post when we successfully save a new object. 
                            return Created($"/api/trips/{tripName}/stops/{newStop.Name}", Mapper.Map<StopViewModel>(newStop));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to save new stop: {ex}");
            }

            return BadRequest("Failed to save new stop");
        }
    }
}
