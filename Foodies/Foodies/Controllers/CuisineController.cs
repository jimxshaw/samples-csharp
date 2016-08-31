using Foodies.Filters;
using System.Web.Mvc;

namespace Foodies.Controllers
{
    [LogAttribute]
    public class CuisineController : Controller
    {
        // GET: Cuisine
        public ActionResult Search(string name = "french")
        {

            var message = Server.HtmlEncode(name);

            return Content(message);
        }
    }
}