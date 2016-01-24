using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishTankApp.ViewModels;

namespace FishTankApp.Services
{
    // The purpose of creating an interface is so that we can register this 
    // service in the Starup class.
    public interface IViewModelService
    {
        DashboardViewModel GetDashboardViewModel();
    }
}
