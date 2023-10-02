using System;
using System.Collections.Generic;

namespace SpaceInvadersV3
{
    public class Spaceship
    {
        public int X { get; set; } // X-coordinate of the spaceship
        public int Y { get; set; } // Y-coordinate of the spaceship

        // Constructor to create a new spaceship with specified coordinates
        public Spaceship(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void MoveLeft()
        {
            if (X > 3)
            {
                X--;
            }
        }

        public void MoveRight(int consoleWidth)
        {
            if (X < consoleWidth - 8) // Assuming the spaceship width is 8 characters
            {
                X++;
            }
        }


        // Create a new bullet and add it to the list of bullets
        public void Shoot(List<Bullet> bullets)
        {
            int bulletX = X + 2; // Adjust the X-coordinate for the bullet to come from the middle
            bullets.Add(new Bullet(bulletX, Y, ConsoleColor.Red)); // Change the color as desired
        }

        // Render the spaceship on the console
        public void Render()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(X - 3, Y);
            Console.Write(@"/o|^|o\");
            Console.ResetColor();
        }
    }
}

