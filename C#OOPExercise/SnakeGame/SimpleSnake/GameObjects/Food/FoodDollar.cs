using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Food
{
    public class FoodDollar : Food
    {
        private const char FoodSymbol = '$';
        private const int Points = 2;
        private const ConsoleColor color = ConsoleColor.Green;

        public FoodDollar(Wall wall)
            : base(wall, FoodSymbol, Points,color)
        {
        }
    }
}
