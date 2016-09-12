using System;
using System.Windows.Forms;

/* 
     Application programs that the Abstract Factory Pattern is attempting to solve:
     - Our app needs to support multiple database types
            - SQL Server, Oracle, MySQL etc.
            - Isolate database types, database sources or report types from the rest of the application
     
     What does the Abstract Factory Pattern do:
     - Provides an abstract class
            - generalized interface
            - Hides details like the database or data source from the rest of the application
            - Factory class creates an instance of a class that inherits or implements the abstract class
            - Used in conjunction with the Factory Method patter
*/

namespace AbstractFactory
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
