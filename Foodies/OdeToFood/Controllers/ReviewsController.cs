using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeToFood.Models;

namespace OdeToFood.Controllers
{
    public class ReviewsController : Controller
    {
        static List<RestaurantReview> _reviews = new List<RestaurantReview>
        {
            new RestaurantReview
            {
                Id = 1,
                Body = "Expensive but worth it.",
                Rating = 10,
                RestaurantId = 1
            },
            new RestaurantReview
            {
                Id = 2,
                Body = "Good selection of dishes.",
                Rating = 7,
                RestaurantId = 2
            },
            new RestaurantReview
            {
                Id = 3,
                Body = "It's cheap.",                    
                Rating = 6,
                RestaurantId = 3
            }
        };

        [ChildActionOnly]
        public ActionResult BestReview()
        {
            var bestReview = _reviews.OrderByDescending(r => r.Rating).Select(r => r).First();

            return PartialView("_Review", bestReview);
        }

        //
        // GET: /Reviews/

        public ActionResult Index()
        {
            var model = _reviews.Select(r => r);

            return View(model);
        }

        //
        // GET: /Reviews/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Reviews/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Reviews/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Reviews/Edit/5

        public ActionResult Edit(int id)
        {
            var review = _reviews.Single(r => r.Id == id);

            return View(review);
        }

        //
        // POST: /Reviews/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var review = _reviews.Single(r => r.Id == id);

            if (TryUpdateModel(review))
            {
                // ...

                return RedirectToAction("Index");
            }

            return View(review);
        }

        //
        // GET: /Reviews/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Reviews/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
