using Foodies.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Foodies.Controllers
{
    public class ReviewsController : Controller
    {
        private static List<RestaurantReview> _reviews = new List<RestaurantReview>()
        {
            new RestaurantReview()
            {
                City = "Dallas",
                Country = "USA",
                Name = "Dragon Cafe",
                Id = 3268,
                Rating = 8,
                State = "TX",
                ZipCode = "76842"

            },
            new RestaurantReview()
            {
                City = "New York",
                Country = "USA",
                Name = "Katz Deli",
                Id = 1111,
                Rating = 9,
                State = "NY",
                ZipCode = "12345"

            },
            new RestaurantReview()
            {
                City = "San Francisco",
                Country = "USA",
                Name = "West Coast Roast",
                Id = 8989,
                Rating = 6,
                State = "CA",
                ZipCode = "45688"

            },
            new RestaurantReview()
            {
                City = "Chicago",
                Country = "USA",
                Name = "Johnny Boy",
                Id = 2366,
                Rating = 8,
                State = "IL",
                ZipCode = "63589"

            },
            new RestaurantReview()
            {
                City = "Portland",
                Country = "USA",
                Name = "Seashore Lodge",
                Id = 3314,
                Rating = 5,
                State = "OR",
                ZipCode = "93144"

            }
        };

        // GET: Reviews
        public ActionResult Index()
        {
            return View();
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reviews/Create
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

        // GET: Reviews/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reviews/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reviews/Delete/5
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
