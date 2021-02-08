using System;
using System.Collections.Generic;
using System.Linq;

namespace _3CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, int> minNumber = numbers =>
            {
                int minNum = int.MaxValue;

                foreach (int num in numbers)
                {
                    if (num < minNum)
                    {
                        minNum = num;
                    }
                }
                return minNum;
            };
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int minnNumber = minNumber(numbers);
            Console.WriteLine(minnNumber);
        }
        //static Func<int,int> MinResult(int number)
        //{
        //    return Func<int number,int nnumber >;
        //}
    }
}
