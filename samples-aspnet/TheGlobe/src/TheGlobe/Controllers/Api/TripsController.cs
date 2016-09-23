﻿using Microsoft.AspNetCore.Mvc;
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
        public JsonResult Get()
        {
            return Json(new Trip()
            {
                Name = "My Trip"
            });
        }
    }
}
