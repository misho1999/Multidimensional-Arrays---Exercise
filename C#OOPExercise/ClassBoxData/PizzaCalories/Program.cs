using System;

namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isBreak = true;
            var pizzaName = Console.ReadLine().Split()[1];
            var doughData = Console.ReadLine().Split();

            var flourType = doughData[1];
            var bakingTechnique = doughData[2];
            var weight = int.Parse(doughData[3]);

            var dough = new Dough(flourType, bakingTechnique, weight);
            var pizza = new Pizza(pizzaName, dough);

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }

                var parts = line.Split();

                var toppingName = parts[1];
                var toppingWeight = int.Parse(parts[2]);

                try
                {
                var topping = new Topping(toppingName, toppingWeight);

                pizza.AddTopping(topping);

                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                    isBreak = false;
                    break;
                }

            }
            if (isBreak )
            {
            Console.WriteLine($"{pizza.Name} - {pizza.GetCalories():F2} Calories.");

            }
        }
    }
}
