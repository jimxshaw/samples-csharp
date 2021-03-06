﻿using ForgetTheMilk.Controllers;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ForgetTheMilk.Models
{
    public class Task
    {
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public string Link { get; set; }

        // Even though we're injecting a LinkValidator, we set the default to null so by
        // default we won't expect a link validator to be passed in. This way we don't 
        // necessarily have to provide a link validator to all of our test methods.  
        public Task(string task, DateTime today, ILinkValidator linkValidator = null)
        {
            Description = task;

            var dueDatePattern = new Regex(@"(jan|feb|mar|apr|may|jun|jul|aug|sep|oct|nov|dec)\s(\d+)");

            var hasDueDate = dueDatePattern.IsMatch(task);

            if (hasDueDate)
            {
                var dueDate = dueDatePattern.Match(task);
                var monthInput = dueDate.Groups[1].Value;
                var month = DateTime.ParseExact(monthInput, "MMM", CultureInfo.CurrentCulture).Month;
                var day = Convert.ToInt32(dueDate.Groups[2].Value);
                var year = today.Year;

                var shouldWrapYear = month < today.Month || (month == today.Month && day < today.Day);
                if (shouldWrapYear)
                {
                    year++;
                }

                if (day <= DateTime.DaysInMonth(year, month))
                {
                    DueDate = new DateTime(year, month, day);
                }
            }

            var linkPattern = new Regex(@"(http://[^\s]+)");
            var hasLink = linkPattern.IsMatch(task);

            if (hasLink)
            {
                var link = linkPattern.Match(task).Groups[1].Value;
                linkValidator.Validate(link);
                Link = link;
            }
        }
    }
}
