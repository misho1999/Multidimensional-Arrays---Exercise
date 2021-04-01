using SimpleSnake.Core.Contracts;
using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SimpleSnake.Core
{
    public class Engine : IEngine
    {
        private readonly Point[] pointsOfDirection;
        private Direction direction;
        private readonly Snake snake;
        private readonly Wall wall;
        private double sleepTime;
        public Engine(Wall wall, Snake snake)
        {
            this.wall = wall;
            this.snake = snake;

            this.sleepTime = 100;
            this.pointsOfDirection = new Point[4];
        }
        public void Run()
        {
            this.CreateDirections();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    this.GetNextDirection();
                }

                bool isMoving = this.snake
                .IsMoving(this.pointsOfDirection[(int)this.direction]);

                if (!isMoving)
                {
                    this.AskUserForRestart();
                }

                this.PrintStatisticksInfo();

                sleepTime -= 0.01;
                Thread.Sleep((int)sleepTime);
            }


        }

        private void PrintStatisticksInfo()
        {
            int leftX = this.wall.LeftX + 2;
            int topY = 3;
            Console.SetCursorPosition(leftX, topY - 1);
            Console.Write(new string('-', 18));

            Console.SetCursorPosition(leftX, topY);
            Console.Write($"Player points: {this.snake.SnakePoints}");

            Console.SetCursorPosition(leftX, topY + 1);
            Console.Write($"Player Level: {this.snake.Level}");

            Console.SetCursorPosition(leftX, topY + 2);
            Console.Write(new string('-', 18));

        }

        private void AskUserForRestart()
        {
            int leftX = this.wall.LeftX + 1;
            int topY = 6;

            Console.SetCursorPosition(leftX, topY);

            Console.WriteLine("Would you like to continue? yes/no");

            Console.SetCursorPosition(leftX, topY + 1);
            Console.Write("Your choice: ");


            string input = Console.ReadLine();

            if (input == "yes")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                this.StopGame();
            }
        }

        private void StopGame()
        {
            Console.SetCursorPosition(5, 10);
            Console.Write("Game Over!");
            Environment.Exit(0);
        }

        private void CreateDirections()
        {
            this.pointsOfDirection[0] = new Point(1, 0);
            this.pointsOfDirection[1] = new Point(-1, 0);
            this.pointsOfDirection[2] = new Point(0, 1);
            this.pointsOfDirection[3] = new Point(0, -1);
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.LeftArrow)
            {
                if (this.direction != Direction.Right)
                {
                    this.direction = Direction.Left;
                }
            }
            if (userInput.Key == ConsoleKey.RightArrow)
            {
                if (this.direction != Direction.Left)
                {
                    this.direction = Direction.Right;
                }
            }
            if (userInput.Key == ConsoleKey.UpArrow)
            {
                if (this.direction != Direction.Down)
                {
                    this.direction = Direction.Up;
                }
            }
            if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (this.direction != Direction.Up)
                {
                    this.direction = Direction.Down;
                }
            }

            Console.CursorVisible = false;
        }
    }
}
