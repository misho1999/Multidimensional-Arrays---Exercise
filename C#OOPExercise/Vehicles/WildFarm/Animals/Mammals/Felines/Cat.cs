using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals.Mammals.Femiles;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        private const double BaseWeightModifier = 0.3;
        private static HashSet<string> allAllowedFoods = new HashSet<string>
        {
            nameof(Meat),
            nameof(Vegetable)

        };
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, allAllowedFoods, BaseWeightModifier, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }

    }
}
