using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string numberPattern = @"\d";
            string emojiPattern = @"(:{2}|\*{2})[A-Z][a-z]{2,}\1";
            Regex numReg = new Regex(numberPattern);
            Regex emojiReg = new Regex(emojiPattern);

            string text = Console.ReadLine();
            long coolTreshold = 1;
            numReg.Matches(text)
                .Select(n => n.Value)
                .Select(int.Parse)
                .ToList()
                .ForEach(x => coolTreshold *= x);

            var matches = emojiReg.Matches(text);
            int totalEmojis = matches.Count;
            List<string> coolEmojis = new List<string>();

            foreach (Match item in matches)
            {
                long coolIndex = item.Value
                    .Substring(2, item.Value.Length - 4)
                    .ToCharArray()
                    .Sum(x => (int)x);

                if (coolIndex > coolTreshold)
                {
                    coolEmojis.Add(item.Value);
                }


            }

            Console.WriteLine($"Cool threshold: {coolTreshold}");
            Console.WriteLine($"{totalEmojis} emojis found in the text. The cool ones are:");

            foreach (var item in coolEmojis)
            {
                Console.WriteLine(item);
            }
        }
    }
}
