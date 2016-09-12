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

            var james = new PlayerCharacter(null)
            {
                Name = "James"
            };

            mike.Hit(30);
            sara.Hit(30);
            james.Hit(30);

            Console.ReadLine();
        }
    }
}
