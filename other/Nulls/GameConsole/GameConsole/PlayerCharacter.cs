using System;

namespace GameConsole
{
    public class PlayerCharacter
    {
        public string Name { get; set; }
        public int? DaysSinceLastLogin { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? IsNoob { get; set; }

        // Health defaults to 100.
        public int Health { get; set; } = 100;

        private readonly ISpecialDefense _specialDefense;

        private readonly SpecialDefense _defense;

        public PlayerCharacter(SpecialDefense defense)
        {
            _defense = defense;
        }

        public void Hit(int damage)
        {
            //int damageReduction = 0;

            //if (_specialDefense != null)
            //{
            //    damageReduction = _specialDefense.CalculateDamageReduction(damage);
            //}

            //int totalDamageTaken = damage - damageReduction;

            // Since we wrote a NullDefense class that implements ISpecialDefense, we don't need 
            // to check for null in an if statement anymore.
            int totalDamageTaken = damage - _defense.CalculateDamageReduction(damage);

            Health -= totalDamageTaken;

            Console.WriteLine($"{Name}'s health has been reduced by {totalDamageTaken} to {Health}");
        }

        public PlayerCharacter()
        {
            // A magic number is a developer defined number used to 
            // prevent nulls for value types.

            //DaysSinceLastLogin = -1; // Magic number
            //DateOfBirth = DateTime.MinValue; // Magic number

            // An alternative handling nulls for value types without using 
            // magic numbers would be to use the Nullable<T> class or placing 
            // the ? symbol next to the value type we want to nullify.
            //DaysSinceLastLogin = null;
            //DateOfBirth = null;
        }
    }
}
