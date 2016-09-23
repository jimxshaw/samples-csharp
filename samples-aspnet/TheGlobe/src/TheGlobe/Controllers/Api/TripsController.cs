using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGlobe.Models;

namespace TheGlobe.Controllers.Api
{
    public class TripsController : Controller
    {
        [HttpGet("api/trips")]
        public IActionResult Get()
        {

            return Ok(new Trip()
            {
                Name = "My Trip"
            });
        }
    }
}
