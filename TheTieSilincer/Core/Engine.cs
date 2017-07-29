using System;
using TheTieSilincer.Support;

namespace TheTieSilincer.Core
{
    using TheTieSilincer.Models;

    public class Engine
    {
        public static int currentPossition = 0;
        public void Run()
        {
            ShowWelcomeScreen();           
            Field.LevelBuild();
 
        }
        private static void ShowWelcomeScreen()
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
                    break;
                }

                WelcomeMenu.WelcomeScreen(currentPossition);
                Console.Clear();
            }
        }
    }

  
}
