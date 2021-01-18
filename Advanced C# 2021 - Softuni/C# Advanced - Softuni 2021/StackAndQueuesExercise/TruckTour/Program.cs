using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int pumpsCount = int.Parse(Console.ReadLine());
            Queue<string> pumpsData = new Queue<string>();

            for (int i = 0; i < pumpsCount; i++)
            {
                pumpsData.Enqueue(Console.ReadLine());
            }
            for (int i = 0; i < pumpsCount; i++)
            {
            bool isSuccseful = true;
                int currentPetrol = 0;
                for (int j = 0;  j < pumpsCount;  j++)
                {
                    int[] pumpData = pumpsData.Dequeue()
                        .Split(" ")
                        .Select(int.Parse)
                        .ToArray();
                    pumpsData.Enqueue(string.Join(" ", pumpData));
                    currentPetrol += pumpData[0];

                    currentPetrol -= pumpData[1];
                    if (currentPetrol < 0)
                    {
                        isSuccseful = false;
                    }
                }
                if (isSuccseful)
                {
                    Console.WriteLine(i);
                    break;
                }
                string temdData = pumpsData.Dequeue();
                pumpsData.Enqueue(temdData);
            }
        }
    }
}
