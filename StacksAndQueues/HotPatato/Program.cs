using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
namespace HotPatato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] children = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
            Queue<string> patatoQueue = new Queue<string>(children);
            int patatoTosses = 0;
            while (patatoQueue.Count > 1)
            {

                string kid = patatoQueue.Dequeue();
                if (patatoTosses == n)
                {
                    patatoTosses = 0;
                }
                else
                {
                patatoQueue.Enqueue(kid);
                }
            }
            Console.WriteLine(string.Join(" ", patatoQueue));
        }
    }
}
