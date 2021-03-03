using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Tire
    {
        public double pressure;
        public int age;

        public Tire(double pressure, int age)
        {
            this.pressure = pressure;
            this.age = age;
        }
    }
}
