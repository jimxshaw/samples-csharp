using ForgetTheMilk.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ForgetTheMilk.Controllers
{
    public class TaskController : Controller
    {
        public static readonly List<Task> Tasks = new List<Task>();

        public ActionResult Index()
        {
            return View(Tasks);
        }

        [HttpPost]
        public ActionResult Add(string task)
        {
            var taskItem = new Task(task, DateTime.Today);

            Tasks.Add(taskItem);

            return RedirectToAction("Index");
        }

    }
}