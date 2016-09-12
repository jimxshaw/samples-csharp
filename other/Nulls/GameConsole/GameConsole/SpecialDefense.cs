namespace GameConsole
{
    public abstract class SpecialDefense
    {
        public abstract int CalculateDamageReduction(int totalDamage);

        // Create a private NullDefense singleton class to simplify code 
        // re-use. Whenever an object's defense is 0 then it can use this 
        // NullDefenseSingleton as opposed to instantiating a NullDefense 
        // object every time.
        public static SpecialDefense Null { get; } = new NullDefenseSingleton();

        private class NullDefenseSingleton : SpecialDefense
        {
            public override int CalculateDamageReduction(int totalDamage)
            {
                return 0;
            }
        }
    }
}
