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
            var input = "Buy groceries";
            var task = new Task(input);
            var descriptionShouldBe = "Buy groceries";
            DateTime? dueDateShouldBe = null;

            if (descriptionShouldBe == task.Description && dueDateShouldBe == task.DueDate)
            {
                Console.WriteLine("SUCCESS");
            }
            else
            {
                Console.WriteLine("ERROR");
                Console.WriteLine($"Description: {task.Description}");
                Console.WriteLine($"Due Date: {task.DueDate}");
            }

            input = "Buy groceries may 24";
            task = new Task(input);
            descriptionShouldBe = "Buy groceries may 24";
            dueDateShouldBe = new DateTime(2016, 5, 24);

            if (descriptionShouldBe == task.Description && dueDateShouldBe == task.DueDate)
            {
                Console.WriteLine("SUCCESS");
            }
            else
            {
                Console.WriteLine("ERROR");
                Console.WriteLine($"Description: {task.Description}");
                Console.WriteLine($"Due Date: {task.DueDate}");
            }

            Console.ReadLine();
        }
    }
}
