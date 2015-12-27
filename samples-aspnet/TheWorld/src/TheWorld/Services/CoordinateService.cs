using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace TheWorld.Services
{
    public class CoordinateService
    {
        private ILogger _logger;

        public CoordinateService(ILogger<CoordinateService> logger)
        {
            _logger = logger;
        }

        public CoordinateServiceResult Lookup(string location)
        {
            var result = new CoordinateServiceResult()
            {
                Success = false,
                Message = "Undetermined failure while looking up coordinates"
            };

            // Lookup coordinates
            var googleKey = Startup.Configuration["AppSettings:GoogleKey"];
            var encodedName = WebUtility.UrlEncode(location);
            var url =
                $"https://maps.googleapis.com/maps/api/geocode/json?address={encodedName}&key={googleKey}";

            return result;
        }
    }
}
