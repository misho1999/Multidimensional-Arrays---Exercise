using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects.Food
{
   
    public abstract class Food : Point
    {
        private readonly char foodSymbol;
        private readonly Random random;
        private readonly Wall wallInfo;
        private ConsoleColor foodColor;

        protected Food(Wall wall, char foodSymbol, int foodPoints, ConsoleColor foodColor) : base(wall.LeftX, wall.TopY)
        {
            this.random = new Random();
            this.foodSymbol = foodSymbol;
            this.FoodPoint = foodPoints;
            this.wallInfo = wall;
            this.foodColor = foodColor;
        }

        public int FoodPoint { get; private set; }

        public void SetRandomPosition(Queue<Point> snakeElements)
        {
            this.LeftX = random.Next(2, wallInfo.LeftX - 2);
            this.TopY = random.Next(2, wallInfo.TopY - 2);

            bool isPointOfSnake = snakeElements.Any(p => p.LeftX == this.LeftX && p.TopY == this.TopY);

            while (isPointOfSnake)
            {
                this.LeftX = random.Next(2, wallInfo.LeftX - 2);
                this.TopY = random.Next(2, wallInfo.TopY - 2);

                isPointOfSnake = snakeElements.Any(p => p.LeftX == this.LeftX && p.TopY == this.TopY);
            }
            Console.BackgroundColor = this.foodColor;
            this.Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }
        public bool IsFoodPoint(Point snakeHead) 
        {
            return this.LeftX == snakeHead.LeftX &&
                this.TopY == snakeHead.TopY;

        }
    }
}
