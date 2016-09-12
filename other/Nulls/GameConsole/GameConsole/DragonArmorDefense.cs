namespace GameConsole
{
    public class DragonArmorDefense : SpecialDefense
    {
        public override int CalculateDamageReduction(int totalDamage)
        {
            return 20;
        }
    }
}
