using System;

namespace Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int myRow = 0;
            int myCol = 0;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        myRow = row;
                        myCol = col;
                    }
                }
            }

            string movement = Console.ReadLine();

            int money = 0;

            while (IsPositionValid(myRow,myCol,n,n) == true || money < 50)
            {
                matrix[myRow, myCol] = '-';
                myRow = MoveRow(myRow, movement);
                myCol = MoveCol(myCol, movement);
                
                if (!IsPositionValid(myRow,myCol,n,n))
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    break;
                }
               
                if (char.IsDigit(matrix[myRow, myCol] ))
                {
                    string then = matrix[myRow, myCol].ToString();
                    int now = int.Parse(then);
                    money += now;
                }
                if (money >= 50 )
                {
                    Console.WriteLine($"Good news! You succeeded in collecting enough money!");
                    matrix[myRow, myCol] = 'S';
                    break;
                }
                
                if (matrix[myRow,myCol] == 'O')
                {
                    for (int row = 0; row < n; row++)
                    {
                        for (int col = 0; col < n; col++)
                        {
                            if (matrix[row, col] == 'O')
                            {

                                myRow = row;
                                myCol = col;
                                matrix[myRow, myCol] = '-';
                            }
                        }
                    }
                }
                movement = Console.ReadLine();
            }
            Console.WriteLine($"Money: {money}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
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
            if (movement == "up")
            {
                return row - 1;
            }
            if (movement == "down")
            {
                return row + 1;
            }
            return row;
        }

        public static int MoveCol(int col, string movement)
        {
            if (movement == "left")
            {
                return col - 1;
            }
            if (movement == "right")
            {
                return col + 1;
            }
            return col;
        }
    }
}
