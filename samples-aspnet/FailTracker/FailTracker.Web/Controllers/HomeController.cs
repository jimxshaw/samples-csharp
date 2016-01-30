using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FailTracker.Web.Data;
using StructureMap;

namespace FailTracker.Web.Controllers
{
	public class HomeController : Controller
	{
		public HomeController(ApplicationDbContext context)
		{
			//Do something with context!
		}

		public ActionResult Index()
		{
			return View();
		}
	}
}