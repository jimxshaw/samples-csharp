using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookEntity.Models;

namespace BookEntity.Controllers
{
    public class ReviewsController : Controller
    {
        BooksDbContext context = new BooksDbContext();

        public ActionResult Create(int id)
        {
            ModelGroup.Book book = context.Books.SingleOrDefault(b => b.BookID == id);
            ViewBag.bookName = book.BookName;

            ModelGroup.Review review = new ModelGroup.Review();
            review.BookID = id;

            return View(review);
        }

        [HttpPost]
        public ActionResult Create(ModelGroup.Review review)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ModelGroup.Book book = context.Books.SingleOrDefault(b => b.BookID == review.BookID);
                    book.Reviews.Add(review);
                    context.SaveChanges();

                    return RedirectToAction("Details", "Books", new {id = book.BookID});
                }

                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}