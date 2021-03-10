using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismExercise
{
    public class Validator
    {
        public static void ThrowIfNumbersIsNegative(double number)
        {
            if (number <= 0)
            {
                throw new InvalidOperationException("Fuel must be a positive number");
            }
        }
    }
}
