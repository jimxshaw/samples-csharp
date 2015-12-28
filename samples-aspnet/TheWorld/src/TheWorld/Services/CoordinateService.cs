using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace TheWorld.Services
{
    public class CoordinateService
    {
        private ILogger _logger;

        public CoordinateService(ILogger<CoordinateService> logger)
        {
            _logger = logger;
        }

        public async Task<CoordinateServiceResult> Lookup(string location)
        {
            var result = new CoordinateServiceResult()
            {
                Success = false,
                Message = "Undetermined failure while looking up coordinates"
            };

            // Lookup coordinates
            var bingKey = Startup.Configuration["AppSettings:BingKey"];
            var encodedName = WebUtility.UrlEncode(location);
            var url =
                $"http://dev.virtualearth.net/REST/version/restApi/resourcePath?{encodedName}&key={bingKey}";

            var client = new HttpClient();

            // Using await means the method itself must include the
            // async keyword in the signature. 
            var json = await client.GetStringAsync(url);

            var results = JObject.Parse(json);
            var resources = results["results"][0]["geometry"];

            if (!resources.HasValues)
            {
                result.Message = $"Could not find '{location}' as a location";
            }
            else
            {
                var coordinates = resources["location"];
                result.Latitude = (double)coordinates["lat"];
                result.Longitude = (double)coordinates["lng"];
                result.Success = true;
                result.Message = "Success";
            }

            return result;
        }
    }
}
