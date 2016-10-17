using System;
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

            var dueDatePattern = new Regex(@"oct\s(\d\d)");

            var hasDueDate = dueDatePattern.IsMatch(task);

            if (hasDueDate)
            {
                var dueDate = dueDatePattern.Match(task);
                var day = Convert.ToInt32(dueDate.Groups[1].Value);
                DueDate = new DateTime(today.Year, 10, day);

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
