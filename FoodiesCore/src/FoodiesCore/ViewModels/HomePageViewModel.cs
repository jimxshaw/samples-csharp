using System.Collections.Generic;
using FoodiesCore.Entities;

namespace FoodiesCore.ViewModels
{
    public class HomePageViewModel
    {
        public string CurrentMessage { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

    }
}
