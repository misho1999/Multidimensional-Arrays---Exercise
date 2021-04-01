using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Food
{
    public class FoodAsterisk : Food
    {
        private const char FoodSymbol = '*';
        private const int Points = 1;
        private const ConsoleColor color = ConsoleColor.Red;
        public FoodAsterisk(Wall wall) 
            : base(wall, FoodSymbol, Points,color)
        {
        }
    }
}
