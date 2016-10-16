using ForgetTheMilk.Models;
using System;

namespace ConsoleVerification
{
    // The purpose of this console application project in our solution is for testing.
    // If we can testing simple user input from a console app, it reduces the time and 
    // hassle of repeatedly building, launching and refreshing our bulky web app.
    class Program
    {
        static void Main(string[] args)
        {
            TestDescriptionAndNoDueDate();

            Console.WriteLine();

            TestMayDueDate();

            Console.ReadLine();
        }

        private static void TestDescriptionAndNoDueDate()
        {
            var input = "Buy groceries";
            Console.WriteLine($"Scenario 1: {input}");
            var task = new Task(input);
            var descriptionShouldBe = "Buy groceries";
            DateTime? dueDateShouldBe = null;

            var success = descriptionShouldBe == task.Description && dueDateShouldBe == task.DueDate;
            var failureMessage = "ERROR: "
                    + "\n"
                    + $"Description: {task.Description} -> Should Be: {descriptionShouldBe}"
                    + "\n"
                    + $"Due Date: {task.DueDate} -> Should Be: {dueDateShouldBe}";

            PrintOutcome(success, failureMessage);
        }

        private static void TestMayDueDate()
        {
            var input = "Buy groceries may 24";
            Console.WriteLine($"Scenario 2: {input}");
            var task = new Task(input);
            var descriptionShouldBe = "Buy groceries may 24";
            var dueDateShouldBe = new DateTime(DateTime.Today.Year, 5, 24);

            var success = dueDateShouldBe == task.DueDate;
            var failureMessage = "ERROR: "
                    + "\n"
                    + $"Due Date: {task.DueDate} -> Should Be: {dueDateShouldBe}";

            PrintOutcome(success, failureMessage);
        }

        private static void PrintOutcome(bool success, string failureMessage)
        {
            Console.WriteLine(success ? "SUCCESS" : failureMessage);
        }
    }
}
