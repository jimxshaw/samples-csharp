namespace GameConsole
{
    public class NullDefense : ISpecialDefense
    {
        public int CalculateDamageReduction(int totalDamage)
        {
            // Sensible "do nothing" behavior because this is a 
            // class for null implementation. 
            return 0;
        }
    }
}
