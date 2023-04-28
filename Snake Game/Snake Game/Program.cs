using System;
using System.Text;

namespace Snake_Game;

internal class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Snake Game";
        int SnakeX = 50; // Initial x position of snake
        int SnakeY = 20; // Initial y position of snake
        int foodX = 0; // Initial food x position
        int foodY = 0; // Initial food y position
        int score = 0; // Initial score
        string direction = "right"; // Initial direction of snake
        bool gameOver = false; // Game start/stop

        // Generate food position
        Random randomNumber = new Random();
        foodX = randomNumber.Next(0, Console.WindowWidth);
        foodY = randomNumber.Next(0, Console.WindowHeight);

        // Hide cursor
        Console.CursorVisible = false;

        // Create game loop
        while (!gameOver)
        {
            // Listen for user input
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        direction = "up";
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        direction = "down";
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        direction = "left";
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        direction = "right";
                        break;
                }
            }

            // Clear Console
            Console.Clear();

            // Draw food
            Console.SetCursorPosition(foodX, foodY);
            Console.Write("8");

            // Draw snake
            Console.SetCursorPosition(SnakeX, SnakeY);
            Console.Write(":>");

            // Move snake in the current direction
            switch (direction)
            {
                case "up":
                    SnakeY--;
                    break;
                case "down":
                    SnakeY++;
                    break;
                case "left":
                    SnakeX--;
                    break;
                case "right":
                    SnakeX++;
                    break;
            }

            // Check for collision with food
            if (SnakeX == foodX && SnakeY == foodY)
            {
                // Increase score
                score++;

                // Generate new food position
                foodX = randomNumber.Next(0, Console.WindowWidth);
                foodY = randomNumber.Next(0, Console.WindowHeight);
            }

            // Check for game over
            if (SnakeX >= Console.WindowWidth || SnakeX < 0 || SnakeY >= Console.WindowHeight || SnakeY < 0)
            {
                Console.WriteLine("Game Over! Please, press \"any\" button to exit");
                Console.ReadKey();
                gameOver = true;
            }

            // Update score
            Console.SetCursorPosition(Console.WindowWidth - 10, 0);
            Console.Write("Score: {0}", score);

            // Delay
            Thread.Sleep(100);
        }
    }
}




