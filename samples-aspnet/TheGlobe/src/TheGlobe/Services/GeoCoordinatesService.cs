using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TheGlobe.Services
{
    public class GeoCoordinatesService
    {
        private IConfigurationRoot _configuration;
        private ILogger<GeoCoordinatesService> _logger;

        public GeoCoordinatesService(ILogger<GeoCoordinatesService> logger, IConfigurationRoot configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<GeoCoordinatesResult> GetCoordinates(string name)
        {
            var result = new GeoCoordinatesResult()
            {
                Successful = false,
                Message = "Failed to get coordinates"
            };

            var apiKey = _configuration["Keys:BingKey"];

            var encodedName = WebUtility.UrlEncode(name);

            var url = $"http://dev.virtualearth.net/REST/v1/Locations?q={encodedName}&key={apiKey}";

            var client = new HttpClient();

            var json = await client.GetStringAsync(url);

            // Read out the results
            // Fragile, might need to change if the Bing API changes
            var results = JObject.Parse(json);
            var resources = results["resourceSets"][0]["resources"];
            if (!results["resourceSets"][0]["resources"].HasValues)
            {
                result.Message = $"Could not find '{name}' as a location";
            }
            else
            {
                var confidence = (string)resources[0]["confidence"];
                if (confidence != "High")
                {
                    result.Message = $"Could not find a confident match for '{name}' as a location";
                }
                else
                {
                    var coordinates = resources[0]["geocodePoints"][0]["coordinates"];
                    result.Latitude = (double) coordinates[0];
                    result.Longitude = (double)coordinates[1];
                    result.Successful = true;
                    result.Message = "Success";
                }
            }

            return result;
        }
    }
}
