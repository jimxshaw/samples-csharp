using System;

namespace GameConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var mike = new PlayerCharacter(new LeatherArmorDefense())
            {
                Name = "Mike"
            };

            var sara = new PlayerCharacter(new DragonArmorDefense())
            {
                Name = "Sara"
            };

            var aaron = new PlayerCharacter(new NullDefense())
            {
                Name = "Aaron"
            };

            var james = new PlayerCharacter(SpecialDefense.Null)
            {
                Name = "James"
            };

            var carol = new PlayerCharacter(SpecialDefense.Null)
            {
                Name = "Carol"
            };

            mike.Hit(30);
            sara.Hit(30);
            aaron.Hit(30);
            james.Hit(30);
            carol.Hit(30);

            Console.ReadLine();
        }
    }
}
