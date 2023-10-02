using System;
using System.Collections.Generic;

namespace SpaceInvadersV3
{
    public class Bullet
    {
        public bool IsActive { get; set; }

        public int X { get; set; } // X-coordinate of the bullet
        public int Y { get; set; } // Y-coordinate of the bullet
        public ConsoleColor Color { get; set; } // Color property of the bullet
        public bool ShouldRemove { get; set; } // Indicates whether the bullet should be removed

        // Constructor to create a new bullet with specified coordinates and color
        public Bullet(int x, int y, ConsoleColor color)
        {
            X = x;
            Y = y;
            Color = color;
            ShouldRemove = false; // Initialize to false
        }

        // Move the bullet upward by decreasing its Y-coordinate
        public void Move()
        {
            Y--;

            // Check if the bullet has moved out of the screen
            if (Y < 0)
            {
                ShouldRemove = true; // Mark the bullet for removal
            }
        }

        // Render the bullet on the console
        public void Render()
        {
            if (IsActive)
            {
                Console.SetCursorPosition(X, Y);
                Console.ForegroundColor = Color;
                Console.Write("•");
                Console.ResetColor();
            }
        }
        public bool HitEnemy(Enemy enemy)
        {
            if (X == enemy.X && Y == enemy.Y)
            {
                enemy.EnemyHealth.DecreaseHealth();
                return true;
            }
            return false;
        }

    }
}
