using System;
using System.Linq;
using System.Collections.Generic;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            char word = ' ';
            int count = 1;
            SortedDictionary<char, int> asd = new SortedDictionary<char, int>();
            for (int i = 0; i < text.Length; i++)
            {
                word = text[i];
                if (asd.Count >= 1)
                {
                    if (asd.ContainsKey(word))
                    {
                        asd[word] += count;
                    }
                    else
                    {
                        asd.Add(word, count);
                    }
                }
                else
                {
                asd.Add(word, count);
                }
            }
            foreach (var item in asd)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
