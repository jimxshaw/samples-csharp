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
            Console.WriteLine($"Scenario 1: {input}");

            var task = new Task(input, default(DateTime));

            var descriptionShouldBe = "Buy groceries";
            DateTime? dueDateShouldBe = null;

            var success = descriptionShouldBe == task.Description && dueDateShouldBe == task.DueDate;
            var failureMessage = "ERROR: "
                    + "\n"
                    + $"Description: {task.Description} -> Should Be: {descriptionShouldBe}"
                    + "\n"
                    + $"Due Date: {task.DueDate} -> Should Be: {dueDateShouldBe}";

            Assert.That(success, failureMessage);
        }
    }
}
