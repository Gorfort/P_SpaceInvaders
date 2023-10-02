using System;
using System.Collections.Generic;
using System.Threading;
using SpaceInvadersV3;

namespace SpaceInvadersV3
{
    class Program
    {
        static void Main()
        {
            Console.CursorVisible = false;

            // Create instances
            Spaceship spaceship = new Spaceship(Console.WindowWidth / 2, Console.WindowHeight - 1);
            List<Bullet> bullets = new List<Bullet>();
            GameEngine gameEngine = new GameEngine(spaceship, bullets);

            // Generate initial enemies
            Enemy.GenerateInitialEnemies(gameEngine);

            StartingScreen startingScreen = new StartingScreen(spaceship, bullets, gameEngine);
            startingScreen.ShowMenu();
        }
    }
}
