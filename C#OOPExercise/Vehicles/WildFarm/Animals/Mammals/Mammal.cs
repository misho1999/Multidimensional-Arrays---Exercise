using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Mammals
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight, HashSet<string> allowedFoods, double weightModifier,string livingRegion) : base(name, weight,allowedFoods, weightModifier)
        {
            this.LivingRegion = livingRegion;
        }
        public string LivingRegion { get; set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
