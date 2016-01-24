using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishTankApp.ViewModels;
using Microsoft.AspNet.Mvc;

namespace FishTankApp.Services
{
    public class ViewModelService : IViewModelService
    {
        private ISensorDataService _sensorDataService;
        private IUrlHelper _urlHelper;

        // When the ViewModelService is injected into the controller, the service container checks
        // if it can fulfill other types in ViewModelService and inject them. Hence, why we're asking 
        // for an ISensorDataService.
        public ViewModelService(ISensorDataService sensorDataService, IUrlHelper urlHelper)
        {
            _sensorDataService = sensorDataService;
            _urlHelper = urlHelper;
        }

        public DashboardViewModel GetDashboardViewModel()
        {
            // The properties of the DashboardViewModel have to be filled. We don't want to put fixed 
            // URLs so we're asking the container for an IUrlHelper instance. It along with the action 
            // method allows for an action name and a controller name arguments. 
            return new DashboardViewModel
            {
                WaterTemperatureTile = new SensorTileViewModel
                {
                    Title = "Water temperature",
                    Value = _sensorDataService.GetWaterTemperatureFahrenheit().Value,
                    ColorCssClass = "panel-primary",
                    IconCssClass = "fa-sliders",
                    Url = _urlHelper.Action("GetWaterTemperatureChart", "History")
                },
                FishMotionTile = new SensorTileViewModel
                {
                    Title = "Fish motion",
                    Value = _sensorDataService.GetFishMotionPercentage().Value,
                    ColorCssClass = "panel-green",
                    IconCssClass = "fa-car",
                    Url = _urlHelper.Action("GetFishMotionPercentageChart", "History")
                },
                WaterOpacityTile = new SensorTileViewModel
                {
                    Title = "Water opacity",
                    Value = _sensorDataService.GetWaterOpacityPercentage().Value,
                    ColorCssClass = "panel-yellow",
                    IconCssClass = "fa-adjust",
                    Url = _urlHelper.Action("GetWaterOpacityPercentageChart", "History")
                },
                LightIntensityTile = new SensorTileViewModel
                {
                    Title = "Light intensity",
                    Value = _sensorDataService.GetLightIntensityLumens().Value,
                    ColorCssClass = "panel-red",
                    IconCssClass = "fa-lightbulb-o",
                    Url = _urlHelper.Action("GetLightIntensityLumensChart", "History")
                }
            };
        }
    }
}
