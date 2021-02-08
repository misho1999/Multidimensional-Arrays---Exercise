using System;
using System.IO.Compression;

namespace ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            using ZipArchive zipFile = ZipFile.Open("../../../zipfile.zip", ZipArchiveMode.Create);
            ZipArchiveEntry zipArchiveEntry = zipFile.CreateEntryFromFile("../../../outputEntry.txt", "../../../output.txt");
        }
    }
}
