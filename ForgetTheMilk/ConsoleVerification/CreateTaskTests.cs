using ForgetTheMilk.Models;
using NUnit.Framework;
using NUnit.Framework.Internal;
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
        [TestCase("Groceries jan 13", 1)]
        [TestCase("Groceries feb 13", 2)]
        [TestCase("Groceries mar 13", 3)]
        [TestCase("Groceries apr 13", 4)]
        [TestCase("Groceries may 13", 5)]
        [TestCase("Groceries jun 13", 6)]
        [TestCase("Groceries jul 13", 7)]
        [TestCase("Groceries aug 13", 8)]
        [TestCase("Groceries sep 13", 9)]
        [TestCase("Groceries oct 13", 10)]
        [TestCase("Groceries nov 13", 11)]
        [TestCase("Groceries dec 13", 12)]
        public void DueDate(string input, int expectedMonth)
        {
            var task = new Task(input, default(DateTime));

            Expect(task.DueDate, Is.Not.Null);
            Expect(task.DueDate.Value.Month, Is.EqualTo(expectedMonth));
        }

        [Test]
        public void TwoDigitDay_ParseBothDigits()
        {
            var input = "Exercise sep 18";

            var task = new Task(input, default(DateTime));

            Expect(task.DueDate.Value.Day, Is.EqualTo(18));
        }

        [Test]
        public void DayIsPastTheLastDayOfTheMonth_DoesNotParseDueDate()
        {
            var input = "Exercise sep 63";

            var task = new Task(input, default(DateTime));

            Expect(task.DueDate, Is.Null);
        }
    }
}
