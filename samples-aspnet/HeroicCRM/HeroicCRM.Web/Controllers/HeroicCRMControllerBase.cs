using System.Web.Mvc;
using HeroicCRM.Web.ActionResults;

namespace HeroicCRM.Web.Controllers
{
    public abstract class HeroicCRMControllerBase : Controller
    {
        // This method takes in a model and returns a BetterJsonResult 
        // containing that model. We can now call BetterJsonResult from 
        // any of our derived controllers instead of calling the standard 
        // json helper.  
        public BetterJsonResult<T> BetterJson<T>(T model)
        {
            return new BetterJsonResult<T>() { Data = model };
        }
    }
}