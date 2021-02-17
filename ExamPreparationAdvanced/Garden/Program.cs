using System;
using System.Collections.Generic;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> saver = new Dictionary<int, int>();
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = arr[0];
            int m = arr[1];

            int[,] matrix = new int[n, m];

            while (true)
            {

                string[] currentPlants = Console.ReadLine().Split();
                if (currentPlants[0] == "Bloom")
                {
                    foreach (var item in saver)
                    {
                        for (int row = 0; row < n; row++)
                        {

                            if (row == item.Key)
                            {
                                continue;
                            }
                            matrix[row, item.Value]++;

                        }
                            for (int col = 0; col < m; col++)
                            {
                                if (col == item.Value)
                                {
                                    continue;
                                }
                                matrix[item.Key, col]++;
                            }

                    }
                    break;
                }
                int plantRow = int.Parse(currentPlants[0]);
                int plantCol = int.Parse(currentPlants[1]);
                if (plantRow > n || plantCol > m)
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                else if (plantRow < 0 || plantCol < 0)
                {
                    Console.WriteLine("Invalid coordinates.");

                }
                else
                {
                saver.Add(plantRow, plantCol);
                matrix[plantRow, plantCol]++;
                }


            }
            //for (int row = 0; row < n; row++)
            //{
            //    string currentRow = Console.ReadLine();
            //    for (int col = 0; col < m; col++)
            //    {
            //        matrix[row, col] = currentRow[col];
            //    }
            //}

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
        public static bool IsPositionValid(int row, int col, int rows, int cols)
        {
            if (row < 0 || row >= rows)
            {
                return false;
            }
            if (col < 0 || col >= cols)
            {
                return false;
            }
            return true;
        }
        public static int MoveRow(int row, string movement)
        {
            if (movement == "Up")
            {

                return row - 1;
            }
            if (movement == "Down")
            {
                return row + 1;
            }
            return row;
        }

        public static int MoveCol(int col, string movement)
        {
            if (movement == "Left")
            {
                return col - 1;
            }
            if (movement == "Right")
            {
                return col + 1;
            }
            return col;
        }
    }
}

