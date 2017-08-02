using System;
using TheTieSilincer.Models;

namespace TheTieSilincer.Core
{
    using TheTieSilincer.Models.Ships;

    public class Game
    {
        private Satellite satellite;
        private ShipManager shipManager;
        private PlayerManager playerManager;


        public Game()
        {
            this.shipManager = new ShipManager();
            this.playerManager = new PlayerManager();
            this.shipManager.GenerateShips();
            this.playerManager.CreatePlayer(this.shipManager.BuildPlayerShip("PlayerShip"));
            this.satellite = new Satellite(playerManager, shipManager);
            this.satellite.ReceiveDataByPlayer();
        }



        public void Clear()
        {
            this.playerManager.ClearPlayer();
            this.shipManager.ClearShips();
        }

    //   public void CheckCollisions()
    //   {
    //       for (int i = 0; i < this.shipManager.Ships.Count; i++)
    //       {
    //           var ship = this.shipManager.Ships[i];
    //
    //           for (int j = 0; j < this.player.Ship.Weapon.Bullets.Count; j++)
    //           {
    //               var bullet = this.player.Ship.Weapon.Bullets[j];
    //               if (bullet.Position.X - 3 < ship.Position.X && bullet.Position.X + 2 > ship.Position.X && bullet.Position.Y + 4 > ship.Position.Y && bullet.Position.Y - 4 < ship.Position.Y)
    //               {
    //                   player.Ship.Weapon.Bullets.Remove(bullet);
    //                   ship.ClearShip();
    //                   shipManager.Ships.Remove(ship);
    //
    //
    //                   break;
    //               }
    //           }
    //       }
    //   }

        public void Update()
        {
            this.playerManager.UpdatePlayer();
            this.shipManager.UpdateShips();

            this.satellite.TransmitMessages();

        }

        public void Draw()
        {
            this.playerManager.DrawPlayer();
            this.shipManager.DrawShips();
        }

        public void InitialiseSettings()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.WindowHeight = 30;
            Console.WindowWidth = 100;
            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;

            this.playerManager.DrawPlayer();
        }      
    }
}


