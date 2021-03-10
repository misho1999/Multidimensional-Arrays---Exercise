using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Mammals.Femiles
{
    public abstract class Feline : Mammal
    {

        protected Feline(string name, double weight, HashSet<string> allowedFoods, double weightModifier, string livingRegion, string breed) : base(name, weight, allowedFoods, weightModifier, livingRegion)
        {
            this.Breed = breed;
        }
        public string Breed { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
