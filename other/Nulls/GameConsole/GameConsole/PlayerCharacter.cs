using System;

namespace GameConsole
{
    public class PlayerCharacter
    {
        public string Name { get; set; }
        public Nullable<int> DaysSinceLastLogin { get; set; }
        public Nullable<DateTime> DateOfBirth { get; set; }

        public PlayerCharacter()
        {
            // A magic number is a developer defined number used to 
            // prevent nulls for value types.

            //DaysSinceLastLogin = -1; // Magic number
            //DateOfBirth = DateTime.MinValue; // Magic number

            // An alternative handling nulls for value types without using 
            // magic numbers would be to use the Nullable<T> class or placing 
            // the ? symbol next to the value type we want to nullify.
            DaysSinceLastLogin = null;
            DateOfBirth = null;
        }
    }
}
