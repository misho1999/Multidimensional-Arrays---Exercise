using System;
using System.IO;

namespace CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using FileStream reader = new FileStream("../../../copyMe.png", FileMode.Open);
            using FileStream writer = new FileStream("../../../NEWcopyMe.png", FileMode.Create);

            while (reader.Position < reader.Length)
            {
                byte[] buffer = new byte[4096];
                int count = reader.Read(buffer, 0, buffer.Length);

                writer.Write(buffer);
            }
        }
    }
}
