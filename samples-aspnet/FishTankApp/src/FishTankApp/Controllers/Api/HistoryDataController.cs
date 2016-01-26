using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishTankApp.Models;
using FishTankApp.Services;
using Microsoft.AspNet.Mvc;

namespace FishTankApp.Controllers.Api
{
    // In asp.net 5, web api and mvc are unified. Where in previous versions, a
    // controller used in a web api would inherit from ApiController, it now 
    // inherits simply from Controller instead. 
    public class HistoryDataController : Controller
    {
        private readonly ISensorDataService _sensorDataService;

        public HistoryDataController(ISensorDataService sensorDataService)
        {
            _sensorDataService = sensorDataService;
        }

        public IEnumerable<IntHistoryModel> GetWaterTemperatureHistory()
        {
            return _sensorDataService.GetWaterTemperatureFahrenheitHistory();
        }

        public IEnumerable<IntHistoryModel> GetFishMotionPercentageHistory()
        {
            return _sensorDataService.GetFishMotionPercentageHistory();
        }

        public IEnumerable<IntHistoryModel> GetWaterOpacityPercentageHistory()
        {
            return _sensorDataService.GetWaterOpacityPercentageHistory();
        }
        public IEnumerable<IntHistoryModel> GetLightIntensityLumensHistory()
        {
            return _sensorDataService.GetLightIntensityLumensHistory();
        }
    }
}
