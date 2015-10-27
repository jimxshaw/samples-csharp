using System;
using System.Web.Mvc;

namespace SimpleBlogMVC.Infrastructure
{
    // The selected tab highlighting will only apply to classes or methods
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class SelectedTabAttribute : ActionFilterAttribute
    {
        private readonly string _selectedTab;

        public SelectedTabAttribute(string selectedTab)
        {
            _selectedTab = selectedTab;
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            // The ViewBag has to be retieved in order for the filter to communiate with the view
            filterContext.Controller.ViewBag.SelectedTab = _selectedTab;
        }
    }
}