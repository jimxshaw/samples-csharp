using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceExample
{
    class Program
    {
        /// <summary>
        /// Inheritance (is-A relationship)and composition (has-A relationship) allows for code reuse.
        /// Problems with inheritance: easy abuse by amateur devs, large hierarchies, fragility and tight code coupling.
        /// Any inheritance relationship can be translated to composition, which has code flexibility and is loosely coupled.
        /// </summary>
        static void Main(string[] args)
        {
            // Inheritance in action
            var text = new Text();
            text.Width = 200;
            text.Height = 500;
            text.Copy();


            // Composition in acton
            var dbMigrator = new DbMigrator(new Logger());

            var logger = new Logger();
            var installer = new Installer(logger);

            dbMigrator.Migrate();
            installer.Install();

            Console.ReadLine();
        }
    }
}
