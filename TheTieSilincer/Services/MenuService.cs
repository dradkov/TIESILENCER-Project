using System;
using TheTieSilincer.Support;

namespace TheTieSilincer.Services
{
    public class MenuService
    {
        private static int currentPossition = 0;

        public static void WelcomeMenuScreenSelection()
        {
            switch (currentPossition)//TODO Add back functionality
            {
                case 0://Log in Functionality
                    RegisterMenu.LogInScreen();
                    MenuService.ShowLogInScreen();
                    MenuService.LogInScreenSelection();
                    
                    break;

                case 1://Credits SCREEN
                    WelcomeMenu.Credits();
                    break;

                case 2://HIGHSCORES SCREEN
                    WelcomeMenu.Scores();
                    break;

                case 3:
                    Console.Beep(4250, 300);
                    Environment.Exit(0);
                    break;
            }
        }

        public static void LogInScreenSelection()
        {
            switch (currentPossition) 
            {
                case 0://Register New Player
                    RegisterMenu.RegisterNewPlayer();
                    break;

                case 1://Log In
                    RegisterMenu.LogIn();
                    break;

                case 2://Back to Welcome Menu Screen
                    MenuService.ShowWelcomeScreen();
                    MenuService.WelcomeMenuScreenSelection();
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

        public static void ShowLogInScreen()
        {
            RegisterMenu.LogInScreen(currentPossition);

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
                    if (currentPossition > 2)
                    {
                        currentPossition = 0;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.Enter)
                {
                    isSelecting = false;

                }


                RegisterMenu.LogInScreen(currentPossition);
                //Console.Clear();
            }
        }



    }
}
