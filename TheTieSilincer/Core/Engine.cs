using System;
using Data;
using Models;
//using TheTieSilincer.Data;
//using TheTieSilincer.Models.Models;
using TheTieSilincer.Support;

namespace TheTieSilincer.Core
{
    using System;

    //using TheTieSilincer.Data;
    //using TheTieSilincer.Models.Models;
    using System.Threading;
    using TheTieSilincer.Interfaces;
    using TheTieSilincer.Services;

    public class Engine : IEngine
    {
        private IGame game;

        private bool GameOver = false;

        public Engine()
        {
            this.game = new Game();
        }

        public void Run()
        {
            game.InitialiseSettings();
            MenuService.ShowWelcomeScreen();
            MenuService.WelcomeMenuScreenSelection();
            Console.Clear();

            
             

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