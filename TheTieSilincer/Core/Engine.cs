using System;
//using TheTieSilincer.Data;
//using TheTieSilincer.Models.Models;
using TheTieSilincer.Support;

namespace TheTieSilincer.Core
{
    using System.Threading;
    using TheTieSilincer.Models;

    public class Engine
    {
        private bool GameOver = false;
        public static int currentPossition = 0;

        public Engine()
        {
            Game.Init();// yo i am back i smoke a cig show hacks, you have 2 pcs?
            // mAd? should I do a BulletFactory => Game.BulletFactory.CreateBullet(?)?:X why? is it so hard?
            // what do u mean? i am asking if it s right to do it, and will i save the bullets i add??? if there is not a list of them
            // u suggested to remove List<Bullet> from ship classes
            // no, just Game.AddObject()
        }


        public void Run()
        {
            Game.InitialiseSettings();
            ShowWelcomeScreen();
            ScreenSelection(currentPossition);
            Console.Clear();
            // TheTieSilincerContext context = new TheTieSilincerContext();
            //context.Database.Initialize(true);
            //PlayerDb textPlayer = new PlayerDb("ASDA", "AASA");
            //context.PlayerDbs.Add(textPlayer);
            //context.SaveChanges();

            while (!GameOver)
            {

                Game.Clear();
                Game.CheckForCollisions();
                Game.Draw();
                Game.Update();

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
