namespace GameConsole
{
    public class NullDefense : SpecialDefense
    {
        public override int CalculateDamageReduction(int totalDamage)
        {
            // Sensible "do nothing" behavior because this is a 
            // class for null implementation. 
            return 0;
        }
    }
}
