using System;
using System.Linq;
using System.IO;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader reader = new StreamReader("../../../text.txt");
            using StreamWriter writer = new StreamWriter("../../../output.txt");
            string streamReader = reader.ReadLine();
            int countLines = 0;
            int lettersCount = 0;
            int punctuationMarksCount = 0;

            while (streamReader != null)
            {
                countLines++;
                for (int i = 0; i < streamReader.Length; i++)
                {
                   
                    if (char.IsLetter(streamReader[i]))
                    {
                        lettersCount++;
                    }
                    else if (char.IsPunctuation(streamReader[i]))
                    {
                        punctuationMarksCount++;
                    }
                }

                Console.WriteLine($"Line {countLines}:{streamReader}({lettersCount})({punctuationMarksCount})");
                writer.WriteLine($"Line {countLines}:{streamReader}({lettersCount})({punctuationMarksCount})");
                streamReader = reader.ReadLine();
                lettersCount = 0;
                punctuationMarksCount = 0;
            }

        }
    }
}
