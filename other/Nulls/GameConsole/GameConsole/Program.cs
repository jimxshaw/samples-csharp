using System;

namespace GameConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayerCharacter player = new PlayerCharacter();

            PlayerDisplayer.Write(player);

            Console.ReadLine();
        }
    }
}
