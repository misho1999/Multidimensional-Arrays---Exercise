using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string name;
        private int weight;
        private const int minWeight = 1;
        private const int maxWeight = 50;
        public Topping(string name, int weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                var valueAsLower = value.ToLower();
                if (valueAsLower != "meat" && valueAsLower != "veggies" && valueAsLower != "cheese" && valueAsLower != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza");
                }
                this.name = value;
            }
        }
        public int Weight
        {
            get => this.weight;
            private set
            {
                Validator.ThrowIfNumberIsNotInRange(minWeight, maxWeight, value, $"{this.name} weight should be in the range [{minWeight}..{maxWeight}].");
                this.weight = value;
            }
        }
        public double GetCalories()
        {
            var modifier = GetModifier();
            return this.Weight * 2 * modifier;
        }

        private double GetModifier()
        {
            var nameLower = this.Name.ToLower();

            if (nameLower == "meat")
            {
                return 1.2;
            }
            if (nameLower == "veggies")
            {
                return 0.8;
            }
            if (nameLower == "cheese")
            {
                return 1.1;
            }
            return 0.9;
        }
    }
}
