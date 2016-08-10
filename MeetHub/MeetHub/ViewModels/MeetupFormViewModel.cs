
using MeetHub.Controllers;
using MeetHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace MeetHub.ViewModels
{
    public class MeetupFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public byte Category { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                // This anonymous method takes in a controller and returns an ActionResult.
                // We put it in an expression that represents the update action in the 
                // MeetupsController.
                Expression<Func<MeetupsController, ActionResult>> update =
                    (c => c.Update(this));
                Expression<Func<MeetupsController, ActionResult>> create =
                    (c => c.Create(this));

                // By using an expression, we can extract the method name at runtime.
                var action = (Id != 0) ? update : create;
                var actionName = (action.Body as MethodCallExpression).Method.Name;
                // If we're dealing with a new meetup, our action will be Create but 
                // if we're dealing with an existing meetup then our action will be Update. 
                return actionName;
            }
        }

        public DateTime GetDateTime()
        {
            return DateTime.Parse($"{Date} {Time}");
        }
    }
}