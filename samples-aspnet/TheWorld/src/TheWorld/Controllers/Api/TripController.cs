﻿using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TheWorld.Models;
using TheWorld.ViewModels;

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
        public JsonResult Post([FromBody]TripViewModel newTrip)
        {
            if (ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.Created;
                return Json(true);
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { Message = "Failed", ModelState = ModelState });
        }
    }
}
