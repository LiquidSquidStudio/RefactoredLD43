using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ReflectionFactory
{
    public abstract class Ability
    {
        public abstract string Name { get; }

        public abstract void Process();
    }

    public class StartFireAbility: Ability
    {
        public override string Name => "fire";

        public override void Process()
        {
            // Make fire
        }
    }

    public class HealAbility : Ability
    {
        public override string Name => "heal";

        public override void Process()
        {
            // Heal
        }
    }

    public class AbilityFactory
    {
        private Dictionary<string, Type> abilitiesByName;

        public AbilityFactory()
        {
            var abilityTypes = Assembly.GetAssembly(typeof(Ability)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Ability)));

            abilitiesByName = new Dictionary<string, Type>();

            foreach (var type in abilityTypes)
            {
                var tempEffect = Activator.CreateInstance(type) as Ability;
                abilitiesByName.Add(tempEffect.Name, type);
            }
        }

        public Ability GetAbility(string abilityName)
        {
            if (abilitiesByName.ContainsKey(abilityName))
            {
                Type type = abilitiesByName[abilityName];
                var ability = Activator.CreateInstance(type) as Ability;
                return ability;
            }

            return null;
        }

        internal IEnumerable<string> GetAbilityNames()
        {
            return abilitiesByName.Keys;
        }
    }
}
