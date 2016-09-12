using System;

namespace GameConsole
{
    public static class PlayerDisplayer
    {
        public static void Write(PlayerCharacter player)
        {

            Console.WriteLine(string.IsNullOrWhiteSpace(player.Name)
                ? "Player name cannot be null or have only white space"
                : $"Name: {player.Name}");

            int days = player.DaysSinceLastLogin ?? -1;
            Console.WriteLine($"{days} days in last login");

            //Console.WriteLine(!player.DaysSinceLastLogin.HasValue
            //    ? "No value for DaysSinceLastLogin"
            //    : $"Days since last login: {player.DaysSinceLastLogin}");

            Console.WriteLine(!player.DateOfBirth.HasValue
                ? "No DateOfBirth has been specified"
                : $"Date of birth: {player.DateOfBirth.Value.ToShortDateString()}");

            Console.WriteLine(!player.IsNoob.HasValue
                ? "Player newbie status is unknown"
                : $"Is noob: {player.IsNoob}");


        }
    }
}
