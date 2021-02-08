using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = Directory.GetCurrentDirectory();
            string[] fileNames = Directory.GetFiles(directoryPath);
            Dictionary<string, Dictionary<string, double>> filesData = new Dictionary<string, Dictionary<string, double>>();

            foreach (string fileName in fileNames)
            {
                FileInfo fileInfo = new FileInfo(fileName);
                string extension = fileInfo.Extension;
                long size = fileInfo.Length;
                double kbSize = Math.Round(size / 1024.0, 3);

                if (!filesData.ContainsKey(extension))
                {
                    filesData.Add(extension, new Dictionary<string, double>());
                }
                filesData[extension].Add(fileInfo.Name, kbSize);
            }
            Dictionary<string, Dictionary<string, double>> sortedDic = filesData
                .OrderByDescending(kvp => kvp.Value.Count)
                .ThenBy(kvp => kvp.Key)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            List<string> result = new List<string>();
            foreach (var item in sortedDic)
            {
                result.Add(item.Key);
                foreach (var file in item.Value.OrderBy(kvp => kvp.Value))
                {
                    result.Add($"--{file.Key} - {file.Value}kb");
                }
            }

            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            File.WriteAllLines(filePath, result);
        }
    }
}
