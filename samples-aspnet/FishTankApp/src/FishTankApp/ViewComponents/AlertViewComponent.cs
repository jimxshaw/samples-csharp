using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishTankApp.Options;
using FishTankApp.Services;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.OptionsModel;

namespace FishTankApp.ViewComponents
{
    public class AlertViewComponent : ViewComponent
    {
        // A sensor's value has to be compared to the alert component. 
        private ISensorDataService _sensorDataService;
        private ThresholdOptions _thresholdConfig;

        // The config file is requested from the container using the IOptions 
        // interface that enables the injection. The value of the config is needed 
        // to get to the ThresholdOptions instance, which contains the values of our 
        // alertThresholds.json configuration file. 
        public AlertViewComponent(ISensorDataService sensorDataService,
            IOptions<ThresholdOptions> thresholdConfig)
        {
            _sensorDataService = sensorDataService;
            _thresholdConfig = thresholdConfig.Value;
        }

        public IViewComponentResult Invoke()
        {
            var viewModel = new List<string>();

            // Compare the current value from the sensor to the threshold value 
            // and add a message. 

            if (_sensorDataService.GetFishMotionPercentage().Value > _thresholdConfig.FishMotionMax)
                viewModel.Add("Too much fish activity");
            if (_sensorDataService.GetFishMotionPercentage().Value < _thresholdConfig.FishMotionMin)
                viewModel.Add("Looks like we have some dead fish");

            if (_sensorDataService.GetLightIntensityLumens().Value > _thresholdConfig.LightIntensityMax)
                viewModel.Add("Bright light, bright light!");
            if (_sensorDataService.GetLightIntensityLumens().Value < _thresholdConfig.LightIntensityMin)
                viewModel.Add("It's dark out here");

            if (_sensorDataService.GetWaterOpacityPercentage().Value > _thresholdConfig.WaterOpacityMax)
                viewModel.Add("The fish can't see you");
            if (_sensorDataService.GetWaterOpacityPercentage().Value < _thresholdConfig.WaterOpacityMin)
                viewModel.Add("Water too clean");

            if (_sensorDataService.GetWaterTemperatureFahrenheit().Value > _thresholdConfig.WaterTemperatureMax)
                viewModel.Add("Water too hot!");
            if (_sensorDataService.GetWaterTemperatureFahrenheit().Value < _thresholdConfig.WaterTemperatureMin)
                viewModel.Add("Water too cold!");

            return View(viewModel);
        }
    }
}
