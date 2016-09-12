namespace GameConsole
{
    public class LeatherArmorDefense : ISpecialDefense
    {
        public int CalculateDamageReduction(int totalDamage)
        {
            return 5;
        }
    }
}
