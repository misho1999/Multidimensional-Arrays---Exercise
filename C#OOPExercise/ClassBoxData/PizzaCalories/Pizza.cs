using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public  class Pizza
    {
        private const int NameMinLenght = 1;
        private const int NameMaxLenght = 15;
        private List<Topping> topping;
        private const int maxTopping = 10;

        private string name;
        
        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;

            this.topping = new List<Topping>();
        }
        public string Name 
        {
            get => this.name;
            private set 
            {
                if (value.Length < NameMinLenght || value.Length > NameMaxLenght)
                {
                    throw new ArgumentException($"Pizza name should be between {NameMinLenght} and {NameMaxLenght} symbols.");  
                }
                this.name = value;
            }
        }
        public Dough Dough { get; set; }

        public void AddTopping(Topping topping)
        {

            if (this.topping.Count > maxTopping)
            {
                throw new ArgumentException($"Number of toppings should be in range [0..{maxTopping}].");
            }
            this.topping.Add(topping);
        }

        public double GetCalories()
        {
            return this.Dough.GetCalories() + this.topping.Sum(t => t.GetCalories());
        }
    }
}
