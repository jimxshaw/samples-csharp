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
    }
}
