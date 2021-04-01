using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Food
{
    public class FoodHash : Food
    {
        private const char FoodSymbol = '#';
        private const int Points = 2;
        private const ConsoleColor color = ConsoleColor.Blue;

        public FoodHash(Wall wall)
            : base(wall, FoodSymbol, Points,color)
        {
        }
    }
}
