using System;
//using TheTieSilincer.Data;
//using TheTieSilincer.Models.Models;
using TheTieSilincer.Support;

namespace TheTieSilincer.Core
{
    using System.Threading;
    using TheTieSilincer.Models;
    using TheTieSilincer.Services;

    public class Engine
    {
        private Game game;
        private bool GameOver = false;

        public Engine()
        {
            this.game = new Game();
        }


        public void Run()
        {
            game.InitialiseSettings();
            MenuService.ShowWelcomeScreen();
            MenuService.ScreenSelection();
            Console.Clear();
            // TheTieSilincerContext context = new TheTieSilincerContext();
            //context.Database.Initialize(true);
            //PlayerDb textPlayer = new PlayerDb("ASDA", "AASA");
            //context.PlayerDbs.Add(textPlayer);
            //context.SaveChanges();

            while (!GameOver)
            {
                game.Clear();
                game.CheckForCollisions();
                game.Draw();
                game.Update();

                Thread.Sleep(100);
            }
        }
    }
}
