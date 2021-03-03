using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] taskInput = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] threadsInput = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Stack<int> task = new Stack<int>();

            Queue<int> threads = new Queue<int>();

            foreach (var item in taskInput)
            {
                task.Push(item);
            }

            foreach (var item in threadsInput)
            {
                threads.Enqueue(item);
            }

            int targetTaskForKill = int.Parse(Console.ReadLine());

            while (task.Contains(targetTaskForKill))
            {
                int currentTask = task.Peek();
                int currentThreads = threads.Peek();

                if (currentTask == targetTaskForKill)
                {
                    Console.WriteLine($"Thread with value {currentThreads} killed task {currentTask}");
                    break;
                }

                if (currentThreads >= currentTask)
                {
                    threads.Dequeue();
                    task.Pop();
                }
                else if (currentThreads < currentTask)
                {
                    threads.Dequeue();
                }
            }
            foreach (var item in threads)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}
