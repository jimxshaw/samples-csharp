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
        public void TestMonthDueDateWithYearWrap()
        {
            var input = "Buy groceries oct 13";

            var today = new DateTime(2016, 10, 16);

            var task = new Task(input, today);

            Expect(task.DueDate, Is.EqualTo(new DateTime(2017, 10, 13)));
        }

        [Test]
        public void TestMonthDueDateWithoutYearWrap()
        {
            var input = "Buy groceries oct 25";

            var today = new DateTime(2016, 10, 16);

            var task = new Task(input, today);

            Expect(task.DueDate, Is.EqualTo(new DateTime(2016, 10, 25)));
        }
    }
}
