using ForgetTheMilk.Models;
using System;

namespace ConsoleVerification
{
    public class TaskTests
    {
        public void TestDescriptionAndNoDueDate()
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

            Program.PrintOutcome(success, failureMessage);
        }
    }
}
