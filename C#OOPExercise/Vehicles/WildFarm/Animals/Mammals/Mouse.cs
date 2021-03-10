using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals
{
    public class Mouse : Mammal
    {
        private const double BaseWeightModifier = 0.1;
        private static HashSet<string> allAllowedFoods = new HashSet<string>
        {
            nameof(Vegetable),
            nameof(Fruit)
        };
        public Mouse(string name, double weight,string livingRegion) : base(name, weight, allAllowedFoods, BaseWeightModifier, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
