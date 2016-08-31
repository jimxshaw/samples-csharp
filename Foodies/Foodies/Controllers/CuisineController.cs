using System.Web.Mvc;

namespace Foodies.Controllers
{
    public class CuisineController : Controller
    {
        // GET: Cuisine
        public ActionResult Search(string name = "french")
        {
            var message = Server.HtmlEncode(name);

            return Json(new { Message = message, Name = "James" }, JsonRequestBehavior.AllowGet);
        }
    }
}