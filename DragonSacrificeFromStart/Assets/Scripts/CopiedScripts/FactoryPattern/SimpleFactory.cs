namespace SimpleFactory
{
    public abstract class Ability
    {
        public abstract void Process();
    }

    public class StartFireAbility : Ability
    {
        public override void Process()
        {
            // Make a fire
        }
    }

    public class HealSelfAbility : Ability
    {
        public override void Process()
        {
            // Heal
        }
    }

    public class AbilityFactory 
    {
        public Ability GetAbility(string abilityType)
        {
            switch (abilityType)
            {
                case "fire":
                    return new StartFireAbility();
                case "heal":
                    return new HealSelfAbility();
                default:
                    return null;
            }
        }
    }
}
