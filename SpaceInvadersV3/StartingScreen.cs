using System;

namespace SpaceInvadersV3
{
    public class StartingScreen
    {
        private int selectedOption;
        private Spaceship spaceship;
        private List<Bullet> bullets;
        private GameEngine gameEngine;
        private HighScore highScore;

        public StartingScreen(Spaceship ship, List<Bullet> bulletList, GameEngine engine)
        {
            selectedOption = 1;
            spaceship = ship;
            bullets = bulletList;
            gameEngine = engine;
            highScore = new HighScore(this);
        }

        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("\n░██████╗██████╗░░█████╗░░█████╗░███████╗  ██╗███╗░░██╗██╗░░░██╗░█████╗░██████╗░███████╗██████╗░░██████╗");
            Console.WriteLine("██╔════╝██╔══██╗██╔══██╗██╔══██╗██╔════╝  ██║████╗░██║██║░░░██║██╔══██╗██╔══██╗██╔════╝██╔══██╗██╔════╝");
            Console.WriteLine("╚█████╗░██████╔╝███████║██║░░╚═╝█████╗░░  ██║██╔██╗██║╚██╗░██╔╝███████║██║░░██║█████╗░░██████╔╝╚█████╗░");
            Console.WriteLine("░╚═══██╗██╔═══╝░██╔══██║██║░░██╗██╔══╝░░  ██║██║╚████║░╚████╔╝░██╔══██║██║░░██║██╔══╝░░██╔══██╗░╚═══██╗");
            Console.WriteLine("██████╔╝██║░░░░░██║░░██║╚█████╔╝███████╗  ██║██║░╚███║░░╚██╔╝░░██║░░██║██████╔╝███████╗██║░░██║██████╔╝");
            Console.WriteLine("╚═════╝░╚═╝░░░░░╚═╝░░╚═╝░╚════╝░╚══════╝  ╚═╝╚═╝░░╚══╝░░░╚═╝░░░╚═╝░░╚═╝╚═════╝░╚══════╝╚═╝░░╚═╝╚═════╝");

            Console.WriteLine();
            Console.WriteLine(selectedOption == 1 ? " ■ Start Game <" : " ■ Start Game");
            Console.WriteLine(selectedOption == 2 ? " ■ Highscores <" : " ■ Highscores");
            Console.WriteLine(selectedOption == 3 ? " ■ Exit <" : " ■ Exit");

            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.W:
                        // Move selection up
                        if (selectedOption > 1)
                            selectedOption--;
                        break;

                    case ConsoleKey.S:
                        // Move selection down
                        if (selectedOption < 3)
                            selectedOption++;
                        break;

                    case ConsoleKey.Enter:
                        // Perform action based on the selected option
                        switch (selectedOption)
                        {
                            case 1:
                                // Start the game by initializing the GameEngine
                                InitializeGame();
                                return;

                            case 2:
                                // Show highscores using the HighScore class
                                highScore.ShowHighscores(); // Call the method on the highScore instance
                                break;

                            case 3:
                                // Exit the application
                                Environment.Exit(0);
                                break;
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please use W and S to navigate and Enter to select.");
                        break;
                }

                // Redraw the menu with the updated selection
                ShowMenu();
            } while (true);
        }

        private void InitializeGame()
        {
            // Start the GameEngine to begin the game
            gameEngine.Start();
        }
    }
}
