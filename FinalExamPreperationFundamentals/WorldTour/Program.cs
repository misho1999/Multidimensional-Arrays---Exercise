using System;
using System.Linq;

namespace WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string[] input = Console.ReadLine()
                .Split(":");
            

            while (input[0] != "Travel")
            {
                if (input[0] == "Add Stop")
                {
                    int index = int.Parse(input[1]);
                    int count = destination.Count();
                    if (count >= index)
                    {
                        destination = destination.Insert(index, input[2]);
                        
                    }
                }
                else if (input[0] == "Remove Stop")
                {
                    int startIndex = int.Parse(input[1]);
                    int endIndex = int.Parse(input[2]);
                    int count = destination.Count();
                    if (startIndex < count && endIndex < count)
                    {
                        if (startIndex > 0 )
                        {

                            endIndex -= (startIndex - 1);
                            destination = destination.Remove(startIndex, endIndex);
                            
                        }
                        else
                        {
                            endIndex -= startIndex; 
                            destination = destination.Remove(startIndex, endIndex + 1);
                            
                        }
                    }
                }
                else if (input[0] == "Switch")
                {
                    if (destination.Contains(input[1]))
                    {
                        destination = destination.Replace(input[1], input[2]);
                        
                    }
                }
                Console.WriteLine(destination);
                input = Console.ReadLine()
                .Split(":", StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {destination}");
        }
    }
}
