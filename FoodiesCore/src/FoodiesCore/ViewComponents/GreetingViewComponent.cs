using System.Threading.Tasks;
using FoodiesCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodiesCore.ViewComponents
{
    public class GreetingViewComponent : ViewComponent
    {
        private IGreeter _greeter;

        public GreetingViewComponent(IGreeter greeter)
        {
            _greeter = greeter;
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            var model = _greeter.GetGreeting();

            return Task.FromResult<IViewComponentResult>(View("Default", model));
        }
    }
}
