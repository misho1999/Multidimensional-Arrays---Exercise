using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Validator
    {
        public static void ThrowIfNumberIsNotInRange(int min, int max, int number, string exceptionMessage) 
        {
            if (number < min || number > max)
            {
                throw new ArgumentException(exceptionMessage);
            }
        }
    }
}
