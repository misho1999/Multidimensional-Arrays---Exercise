using System;
using System.IO;
using System.Linq;

namespace StreamsAndFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader streamReader = new StreamReader("../../../text.txt");
            int count = 0;
            string chars = "-,.!?";
            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                if (count % 2 == 0)
                {
                    foreach (var item in chars)
                    {
                        line = line.Replace(item, '@');
                    }
                    string[] splittedLine = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();
                    Console.WriteLine(string.Join(" ", splittedLine));
                }
                count++;
            }
        }
    }
}
