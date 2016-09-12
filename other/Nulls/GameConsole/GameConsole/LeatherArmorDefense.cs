namespace GameConsole
{
    public class LeatherArmorDefense : SpecialDefense
    {
        public override int CalculateDamageReduction(int totalDamage)
        {
            return 5;
        }
    }
}
