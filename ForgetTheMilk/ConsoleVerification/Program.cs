﻿using ForgetTheMilk.Models;
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

            Console.WriteLine($"Description: {task.Description}");
            Console.WriteLine($"Due Date: {task.DueDate}");
            Console.WriteLine();

            input = "Buy groceries may 24";
            task = new Task(input);

            Console.WriteLine($"Description: {task.Description}");
            Console.WriteLine($"Due Date: {task.DueDate}");
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
