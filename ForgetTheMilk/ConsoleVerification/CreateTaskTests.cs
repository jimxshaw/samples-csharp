using ForgetTheMilk.Models;
using NUnit.Framework;
using System;

namespace ConsoleVerification
{
    public class CreateTaskTests : AssertionHelper
    {
        [Test]
        public void DescriptionAndNoDueDate()
        {
            var input = "Buy groceries";

            var task = new Task(input, default(DateTime));

            Expect(task.Description, Is.EqualTo(input));
            Assert.AreEqual(null, task.DueDate);
        }

        [Test]
        public void MonthDueDateWithYearWrap()
        {
            var input = "Buy groceries oct 17";

            var today = new DateTime(2016, 10, 23);

            var task = new Task(input, today);

            Expect(task.DueDate, Is.EqualTo(new DateTime(2017, 10, 17)));
        }

        [Test]
        public void MonthDueDateWithoutYearWrap()
        {
            var input = "Buy groceries oct 30";

            var today = new DateTime(2016, 10, 23);

            var task = new Task(input, today);

            Expect(task.DueDate, Is.EqualTo(new DateTime(2016, 10, 30)));
        }

        [Test]
        public void AprilDueDate()
        {
            var input = "Groceries sep 13";

            var today = new DateTime(2016, 10, 30);

            var task = new Task(input, today);

            Expect(task.DueDate, Is.Not.Null);
            Expect(task.DueDate.Value.Month, Is.EqualTo(9));
        }
    }
}
