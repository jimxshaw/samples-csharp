using ForgetTheMilk.Models;
using NUnit.Framework;
using System;

namespace ConsoleVerification
{
    public class CreateTaskTests
    {
        [Test]
        public void DescriptionAndNoDueDate()
        {
            var input = "Buy groceries";

            var task = new Task(input, default(DateTime));

            Assert.AreEqual(input, task.Description);
            Assert.AreEqual(null, task.DueDate);
        }
    }
}
