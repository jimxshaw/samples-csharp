using System;

namespace GameConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayerCharacter player = new PlayerCharacter();
            player.Name = "James";
            player.DaysSinceLastLogin = 8;
            player.DateOfBirth = new DateTime(1968, 12, 7);

            PlayerDisplayer.Write(player);
        }
    }
}
