using System;

namespace GameConsole
{
    public class PlayerCharacter
    {
        public string Name { get; set; }
        public int DaysSinceLastLogin { get; set; }
        public DateTime DateOfBirth { get; set; }

        public PlayerCharacter()
        {
            // A magic number is a developer defined number used to 
            // prevent nulls for value types.

            DaysSinceLastLogin = -1; // Magic number
            DateOfBirth = DateTime.MinValue; // Magic number
        }
    }
}
