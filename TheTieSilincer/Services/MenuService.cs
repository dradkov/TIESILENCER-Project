namespace TheTieSilincer.Services
{
    using System;
    using TheTieSilincer.Support;

    public class MenuService
    {
        private static int currentPossition = 0;

        public static void ScreenSelection()
        {
            switch (currentPossition)//TODO Add back functionality
            {
                case 0://NEW CHARACTER CREATION
                    WelcomeMenu.CreateNewPlayer();
                    break;

                case 1://Credits SCREEN
                    WelcomeMenu.Credits();
                    break;

                case 2://HIGHSCORES SCREEN
                    WelcomeMenu.CreateNewPlayer();
                    break;

                case 3:
                    Console.Beep(4250, 300);
                    Environment.Exit(0);
                    break;
            }
        }

        public static void ShowWelcomeScreen()
        {
            WelcomeMenu.WelcomeScreen(currentPossition);
            bool isSelecting = true;
            while (isSelecting)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                if (pressedKey.Key == ConsoleKey.UpArrow)
                {
                    Console.Beep(7000, 70);
                    currentPossition--;
                    if (currentPossition < 0)
                    {
                        currentPossition = 3;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.DownArrow)
                {
                    Console.Beep(7000, 70);
                    currentPossition++;
                    if (currentPossition > 3)
                    {
                        currentPossition = 0;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.Enter)
                {
                    isSelecting = false;
                }

                WelcomeMenu.WelcomeScreen(currentPossition);
                //Console.Clear();
            }
        }
    }
}