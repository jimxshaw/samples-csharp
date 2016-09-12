using System;

namespace GameConsole
{
    public static class PlayerDisplayer
    {
        public static void Write(PlayerCharacter player)
        {
            Console.WriteLine($"Name: {player.Name}");

            if (player.DaysSinceLastLogin == null)
            {
                Console.WriteLine("No value for DaysSinceLastLogin");
            }
            else
            {
                Console.WriteLine($"Days since last login: {player.DaysSinceLastLogin}");
            }

            if (player.DateOfBirth == null)
            {
                Console.WriteLine("No DateOfBirth has been specified");
            }
            else
            {
                Console.WriteLine($"Date of birth: {player.DateOfBirth.Value.ToShortDateString()}");
            }
        }
    }
}
