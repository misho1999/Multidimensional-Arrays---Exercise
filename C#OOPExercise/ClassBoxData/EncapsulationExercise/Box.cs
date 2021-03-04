using System;
using System.Collections.Generic;
using System.Text;

namespace EncapsulationExercise
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double lenght, double width,double height)
        {
            this.Lenght = lenght;
            this.Width = width;
            this.Height = height;

        }
        public double Lenght 
        {
            get => this.length;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Lenght cannot be zero or negative.");
                }
                this.length = value;
            }
        }
        public double Width
        {
            get => this.width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }
        public double Height
        {
            get => this.height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }
        public double CalculateVolume()
        {
            return this.Width * this.Lenght * this.Height;
        }
        public double CalculateLateralSurfaceArea()
        {

            return 2 * this.Lenght * this.Height + 2 * this.Width * this.Height;
        }
        public double CalculateSurfaceArea()
        {
            return 2 * this.Lenght * this.Width + 2 * this.Lenght * this.Height + 2 * this.Width * this.Height;
        }
    }
}
