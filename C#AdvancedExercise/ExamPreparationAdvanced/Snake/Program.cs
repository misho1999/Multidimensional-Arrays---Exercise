using System;

namespace examPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int snakeRow = 0;
            int snakeCol = 0;
            int food = 0;

            for (int rows = 0; rows < n; rows++)
            {
                string input = Console.ReadLine();

                for (int cols = 0; cols < n; cols++)
                {
                    matrix[rows, cols] = input[cols];

                    if (matrix[rows, cols] == 'S')
                    {
                        snakeRow = rows;
                        snakeCol = cols;
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                matrix[snakeRow, snakeCol] = '.';

                if (command == "up")
                {
                    snakeRow--;

                    if (snakeRow >= 0)
                    {
                        if (matrix[snakeRow, snakeCol] == '*')
                        {
                            food++;
                        }
                        else if (matrix[snakeRow, snakeCol] == 'B')
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            for (int rows = 0; rows < n; rows++)
                            {
                                for (int cols = 0; cols < n; cols++)
                                {
                                    if (matrix[rows, cols] == 'B')
                                    {
                                        snakeRow = rows;
                                        snakeCol = cols;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Game over!");
                        break;
                    }
                }
                else if (command == "down")
                {
                    snakeRow++;

                    if (snakeRow < n)
                    {
                        if (matrix[snakeRow, snakeCol] == '*')
                        {
                            food++;
                        }
                        else if (matrix[snakeRow, snakeCol] == 'B')
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            for (int rows = 0; rows < n; rows++)
                            {
                                for (int cols = 0; cols < n; cols++)
                                {
                                    if (matrix[rows, cols] == 'B')
                                    {
                                        snakeRow = rows;
                                        snakeCol = cols;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Game over!");
                        break;
                    }
                }
                else if (command == "left")
                {
                    snakeCol--;

                    if (snakeCol >= 0)
                    {
                        if (matrix[snakeRow, snakeCol] == '*')
                        {
                            food++;
                        }
                        else if (matrix[snakeRow, snakeCol] == 'B')
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            for (int rows = 0; rows < n; rows++)
                            {
                                for (int cols = 0; cols < n; cols++)
                                {
                                    if (matrix[rows, cols] == 'B')
                                    {
                                        snakeRow = rows;
                                        snakeCol = cols;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Game over!");
                        break;
                    }
                }
                else if (command == "right")
                {
                    snakeCol++;

                    if (snakeCol < n)
                    {
                        if (matrix[snakeRow, snakeCol] == '*')
                        {
                            food++;
                        }
                        else if (matrix[snakeRow, snakeCol] == 'B')
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            for (int rows = 0; rows < n; rows++)
                            {
                                for (int cols = 0; cols < n; cols++)
                                {
                                    if (matrix[rows, cols] == 'B')
                                    {
                                        snakeRow = rows;
                                        snakeCol = cols;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Game over!");
                        break;
                    }
                }

                if (food == 10)
                {
                    Console.WriteLine("You won! You fed the snake.");
                    matrix[snakeRow, snakeCol] = 'S';
                    break;
                }

                matrix[snakeRow, snakeCol] = 'S';
            }

            Console.WriteLine($"Food eaten: {food}");

            for (int rows = 0; rows < n; rows++)
            {
                for (int cols = 0; cols < n; cols++)
                {
                    Console.Write($"{matrix[rows, cols]}");
                }

                Console.WriteLine();
            }
        }
        public static void PrintMatrix(char[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    Console.Write($"{matrix[rows, cols]}");
                }

                Console.WriteLine();
            }
        }
    }
}