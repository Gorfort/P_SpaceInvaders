using System;
using System.Collections.Generic;

namespace SpaceInvadersV3
{
    public class Enemy
    {
        private DateTime lastMoveTime; // Add a field to store the last time the enemy moved
        private List<Bullet> bullets = new List<Bullet>();
        public int X { get; set; } // X-coordinate of the enemy
        public int Y { get; set; } // Y-coordinate of the enemy
        public ConsoleColor Color { get; set; } // Color property of the enemy
        public Health EnemyHealth { get; private set; } // Health of the enemy
        private int hitCount = 0;
        public static double SpawnRate { get; set; } // Adjust the spawn rate as needed (e.g., 0.5 enemies per second)

        public static int Score { get; private set; } // Static property to store the score

        public Enemy(int x, int y, ConsoleColor color)
        {
            X = x;
            Y = y;
            Color = color;
            EnemyHealth = new Health(30); // Initialize with an initial health of 3 (or adjust as needed)                                  
            lastMoveTime = DateTime.Now; // Initialize lastMoveTime with the current time
        }

        public bool IsDestroyed()
        {
            return EnemyHealth.IsDead(); // Calls the IsDead() method
        }

        public void AddEnemy(List<Enemy> enemiesList)
        {
            enemiesList.Add(this);
        }

        public static void UpdateEnemies(List<Enemy> enemiesList, List<Bullet> bulletsList)
        {
            for (int i = enemiesList.Count - 1; i >= 0; i--)
            {
                Enemy enemy = enemiesList[i];

                // Check if any bullets hit the enemy
                if (enemy.IsHit(bulletsList))
                {
                    bulletsList.RemoveAll(bullet => bullet.X == enemy.X && bullet.Y == enemy.Y); // Remove the bullet(s) that hit the enemy

                    // Decrease the enemy's health
                    enemy.EnemyHealth.DecreaseHealth();

                    // If the enemy's health reaches zero, remove it
                    if (enemy.EnemyHealth.IsDead())
                    {
                        enemy.Remove(); // Remove the enemy from the screen
                        enemiesList.RemoveAt(i); // Remove the enemy from the list
                    }
                }
            }
        }

        public void Render()
        {
            // Add this code to display the score at the top of the screen
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Score: {Enemy.Score.ToString().PadLeft(5)}"); // Display the score with leading zeros
            Console.ResetColor();

            if (hitCount >= 25)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (hitCount >= 15)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = Color;
            }

            Console.SetCursorPosition(X, Y);
            Console.Write("-=0=-"); // Adjust this to the appearance you want
            Console.ResetColor();
        }

        // Function to move the enemy (if needed)
        public void Move()
        {
            // Calculate the time elapsed since the last movement
            TimeSpan timeSinceLastMove = DateTime.Now - lastMoveTime;

            // Check if 0.2 seconds have passed since the last movement
            if (timeSinceLastMove.TotalSeconds >= 0.2)
            {
                // Move the enemy to the right
                X++;

                // Check if the enemy is at the right edge of the screen
                if (X >= Console.WindowWidth - 5)
                {
                    // Reset X to the leftmost position and move down one row
                    X = 0;
                    Y++;
                    Y++;
                }

                // Update the lastMoveTime to the current time
                lastMoveTime = DateTime.Now;
            }
        }


        public bool IsHit(List<Bullet> bullets)
        {
            foreach (var bullet in bullets)
            {
                if (bullet.X >= X && bullet.X < X + 5 && bullet.Y == Y)
                {
                    hitCount++; // Increment the hit count
                    Score += 5; // Add 5 points to the score
                    return true; // Bullet hit the enemy
                }
            }
            return false; // No bullets hit the enemy
        }

        // Function to remove the enemy from the screen
        public void Remove()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("     "); // Clear the enemy character (adjust the spaces as needed)
        }

        public static void GenerateInitialEnemies(GameEngine gameEngine)
        {
            int spacing = Console.WindowWidth / 12; // Adjust the spacing between enemies

            for (int i = 0; i < 10; i++)
            {
                int x = i * spacing + 2; // Calculate the X-coordinate based on spacing
                int y = 1; // Position the enemies at the top of the screen
                ConsoleColor color = ConsoleColor.White; // Enemy color

                // Create and add an enemy to the game engine
                Enemy enemy = new Enemy(x, y, color);
                gameEngine.AddEnemy(enemy);
            }
        }
    }
}
