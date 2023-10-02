using System;

namespace SpaceInvadersV3
{
    public class HighScore
    {
        // Add a reference to the StartingScreen class
        private StartingScreen startingScreen;

        public HighScore(StartingScreen screen)
        {
            startingScreen = screen;
        }

        public void ShowHighscores()
        {
            Console.Clear();
            // Display highscores here (you can add your code for this)
            Console.WriteLine("Highscores:");
            Console.WriteLine("1. Player1 - 1000");
            Console.WriteLine("2. Player2 - 800");
            Console.WriteLine("3. Player3 - 600");
            Console.WriteLine("Press any key to go back to the main menu...");

            Console.ReadKey(true);

            // Return to the main menu using the existing StartingScreen instance
            startingScreen.ShowMenu();
        }
    }
}
