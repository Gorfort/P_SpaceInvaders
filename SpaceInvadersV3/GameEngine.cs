using System;
using System.Collections.Generic;
using System.Threading;

namespace SpaceInvadersV3
{
    public class GameEngine
    {
        private Spaceship spaceship;
        private List<Bullet> bullets;
        private List<Enemy> enemies;
        private List<Enemy> enemiesToRemove;


        public GameEngine(Spaceship ship, List<Bullet> bulletList)
        {
            spaceship = ship;
            bullets = bulletList;
            enemies = new List<Enemy>();
            enemiesToRemove = new List<Enemy>();
        }

        public void Start()
        {
            DisplayIntroScreen();

            ConsoleKeyInfo keyInfo;

            while (true)
            {
                foreach (var enemy in enemies)
                {
                    enemy.Move();
                }
                if (Console.KeyAvailable)
                {
                    keyInfo = Console.ReadKey(true);

                    if (keyInfo.Key == ConsoleKey.A)
                    {
                        spaceship.MoveLeft();
                    }

                    if (keyInfo.Key == ConsoleKey.D)
                    {
                        spaceship.MoveRight(Console.WindowWidth);
                    }

                    if (keyInfo.Key == ConsoleKey.Spacebar)
                    {
                        // Create a new bullet and set it as active
                        Bullet bullet = new Bullet(spaceship.X, spaceship.Y, ConsoleColor.White);
                        bullet.IsActive = true;

                        // Add the bullet to the list of bullets
                        bullets.Add(bullet);
                    }
                }

                Console.Clear();
                // Render the spaceship
                spaceship.Render();
                // Update and manage player's bullets
                foreach (var bullet in bullets)
                {
                    if (bullet.IsActive)
                    {
                        bullet.Move();

                        // Remove bullets when they go out of bounds
                        if (bullet.Y < 0)
                        {
                            bullet.IsActive = false;
                        }
                    }
                }

                bullets.RemoveAll(bullet => !bullet.IsActive); // Remove inactive bullets


                // Render the player's bullets
                foreach (var bullet in bullets)
                {
                    bullet.Render();
                }

                // Update and manage enemies
                Enemy.UpdateEnemies(enemies, bullets);

                // Render enemies
                foreach (var enemy in enemies)
                {
                    enemy.Render();
                }

                // Remove enemies that are marked for removal
                foreach (var enemyToRemove in enemiesToRemove)
                {
                    enemies.Remove(enemyToRemove);
                }

                Thread.Sleep(50);
            }
        }

        internal void AddEnemy(Enemy enemy)
        {
            enemies.Add(enemy); // list that holds the enemies
        }


        private void DisplayIntroScreen()
        {
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 - 2);
            Console.WriteLine("Invaders Must Die!");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 16, Console.WindowHeight / 2);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Press space to start the game");
            Console.ForegroundColor = ConsoleColor.White;

            // Wait for the space key to start the game
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Spacebar)
                    {
                        // Start the game
                        return;
                    }
                }
            }
        }
    }
}
