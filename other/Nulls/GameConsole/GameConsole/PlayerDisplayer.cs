using System;

namespace GameConsole
{
    public static class PlayerDisplayer
    {
        public static void Write(PlayerCharacter player)
        {
            Console.WriteLine($"Name: {player.Name}");

            Console.WriteLine(player.DaysSinceLastLogin == null
                ? "No value for DaysSinceLastLogin"
                : $"Days since last login: {player.DaysSinceLastLogin}");

            Console.WriteLine(player.DateOfBirth == null
                ? "No DateOfBirth has been specified"
                : $"Date of birth: {player.DateOfBirth.Value.ToShortDateString()}");

            Console.WriteLine(player.IsNoob == null
                ? "Player newbie status is unknown"
                : $"Is noob: {player.IsNoob}");


        }
    }
}
