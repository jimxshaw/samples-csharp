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

            TestMayDueDateWithYearWrap();

            Console.WriteLine();

            TestMayDueDateWithoutYearWrap();

            Console.ReadLine();
        }

        private static void TestDescriptionAndNoDueDate()
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

            PrintOutcome(success, failureMessage);
        }

        private static void TestMayDueDateWithYearWrap()
        {
            var input = "Buy groceries may 24";
            Console.WriteLine($"Scenario 2: {input}");

            var today = new DateTime(2016, 10, 16);

            var task = new Task(input, today);

            var descriptionShouldBe = "Buy groceries may 24 - as of 2015-10-16";
            var dueDateShouldBe = new DateTime(2017, 5, 24);

            var success = dueDateShouldBe == task.DueDate;
            var failureMessage = "ERROR: "
                    + "\n"
                    + $"Due Date: {task.DueDate} -> Should Be: {dueDateShouldBe}";

            PrintOutcome(success, failureMessage);
        }

        private static void TestMayDueDateWithoutYearWrap()
        {
            var input = "Buy groceries may 24";
            Console.WriteLine($"Scenario 2: {input}");

            var today = new DateTime(2016, 5, 23);

            var task = new Task(input, today);

            var descriptionShouldBe = "Buy groceries may 24 - as of 2016-05-23";
            var dueDateShouldBe = new DateTime(2016, 5, 24);

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
