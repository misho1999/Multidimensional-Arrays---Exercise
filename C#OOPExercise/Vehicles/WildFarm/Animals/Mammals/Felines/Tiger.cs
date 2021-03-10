using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals.Mammals.Femiles;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        private const double BaseWeightModifier = 1;
        private static HashSet<string> allAllowedFoods = new HashSet<string>
        {
            nameof(Meat)

        };
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, allAllowedFoods, BaseWeightModifier, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
