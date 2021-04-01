using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {

        private const char WallSymbol = '\u25A0';
        public Wall(int leftX, int topY) : base(leftX, topY)
        {
            this.InitializeWallBordes();
        }
        private void InitializeWallBordes() 
        {
            this.SetHorizontalLine(0);
            this.SetHorizontalLine(this.TopY);

            this.SetVerticalLine(0);
            this.SetVerticalLine(this.LeftX - 1);
        }
        public bool IsPointOfWall(Point snakePoint) 
        {
            return snakePoint.LeftX == 0 || snakePoint.LeftX == this.LeftX - 1 ||
                snakePoint.TopY == 0 || snakePoint.TopY == this.TopY;
        }

        private void SetHorizontalLine(int topY) 
        {
            for (int leftX = 0; leftX < this.LeftX; leftX++)
            {
                this.Draw(leftX, topY, WallSymbol);
            }
        }
        private void SetVerticalLine(int leftX)
        {
            for (int topY = 0; topY < this.TopY; topY++)
            {
                this.Draw(leftX, topY, WallSymbol);
            }
        }
    }
}
