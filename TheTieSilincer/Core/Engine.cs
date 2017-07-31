using System;
using TheTieSilincer.Support;

namespace TheTieSilincer.Core
{
    using System.Threading;
    using TheTieSilincer.Models;

    public class Engine
    {
        private Game game;
        private bool GameOver = false;
        public static int currentPossition = 0;

        public Engine()
        {
            game = new Game();
        }
        

        public void Run()
        {
            game.InitialiseSettings();
            ShowWelcomeScreen();
            ScreenSelection(currentPossition);
            Console.Clear();
            
            while (!GameOver)
            {

                game.Clear();
               // game.CheckCollisions();
                game.Draw();
                game.Update();
                 
                //Field.LevelBuild();
                 Thread.Sleep(100);
              
            }
            
        }
        private static void ScreenSelection(int currentPossition)
        {
            switch (currentPossition)//TODO Add back functionality
            {
                case 0://NEW CHARACTER CREATION
                    WelcomeMenu.CreateNewPlayer();
                    break;

                case 1://LOAD CHARACTER SCREEN
                    WelcomeMenu.LoadCharacters(0);
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
                
                }


                WelcomeMenu.WelcomeScreen(currentPossition);
                //Console.Clear();
            }
        }
    }


}
