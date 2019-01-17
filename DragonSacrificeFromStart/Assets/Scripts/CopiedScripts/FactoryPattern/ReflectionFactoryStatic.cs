using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace ReflectionFactoryStatic
{
    public abstract class Ability
    {
        public abstract string Name { get; }

        public abstract void Process();
    }

    public class StartFireAbility : Ability
    {
        public override string Name => "fire";

        public override void Process()
        {
            // Do fire
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

    public static class AbilityFactory
    {
        private static Dictionary<string, Type> abilitiesByName;
        private static bool IsInitialized => abilitiesByName != null;

        private static void InitializeFactory()
        {
            if (IsInitialized)
                return;

            var abilityTypes = Assembly.GetAssembly(typeof(Ability)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Ability)));

            abilitiesByName = new Dictionary<string, Type>();

            foreach (var type in abilityTypes)
            {
                var tempEffect = Activator.CreateInstance(type) as Ability;
                abilitiesByName.Add(tempEffect.Name, type);
            }
        }

        public static Ability GetAbility(string abilityName)
        {
            InitializeFactory();

            if (abilitiesByName.ContainsKey(abilityName))
            {
                Type type = abilitiesByName[abilityName];
                var ability = Activator.CreateInstance(type) as Ability;
                return ability;
            }

            return null;
        }

        internal static IEnumerable<string> GetAbilityNames2()
        {
            UnityEngine.Debug.Log("Test");
            InitializeFactory();
            return abilitiesByName.Keys;
        }
    }
}
