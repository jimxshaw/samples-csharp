﻿using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ForgetTheMilk.Models
{
    public class Task
    {
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }

        public Task(string task, DateTime today)
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

                if (day < DateTime.DaysInMonth(year, month))
                {
                    DueDate = new DateTime(year, month, day);

                    if (DueDate < today)
                    {
                        // If the user input date is prior to today's date then we'll assume the
                        // user actually means next year and wrap the year by adding 1.
                        DueDate = DueDate.Value.AddYears(1);
                    }
                }


            }
        }
    }
}
