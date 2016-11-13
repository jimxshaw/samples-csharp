using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FoodiesCore.Controllers
{
    [Route("[controller]")]
    public class AboutController : Controller
    {
        [Route("")] // By not specifying a route explicitly, this will serve as the default action when hitting the about controller.
        public string Home()
        {
            return "1-555-555-5555";
        }

        [Route("[action]")]
        public string Address()
        {
            return "USA";
        }
    }
}
