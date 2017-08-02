using System;
using TheTieSilincer.Models;

namespace TheTieSilincer.Core
{
    using TheTieSilincer.Collisions;
    using TheTieSilincer.Models.Ships;

    public class Game
    {
        private Satellite satellite;

        private ShipManager shipManager;
        private PlayerManager playerManager;

        private BulletCollision bulletCollision;
        private ShipCollision shipCollision;


        public Game()
        {
            this.satellite = new Satellite();
            this.shipManager = new ShipManager();
            this.playerManager = new PlayerManager();
            this.bulletCollision = new BulletCollision(shipManager, playerManager);
            this.shipCollision = new ShipCollision(shipManager);
            this.shipManager.GenerateShips();
            this.playerManager.CreatePlayer(this.shipManager.BuildPlayerShip("PlayerShip"));         
            this.satellite.ReceiveDataByPlayer(playerManager);
        }



        public void Clear()
        {
            this.playerManager.ClearPlayer();
            this.shipManager.ClearShips();
        }

        public void CheckForCollisions()
        {
            this.bulletCollision.CheckForCollisions();
        }

        public void Update()
        {
            this.playerManager.UpdatePlayer();
            this.shipManager.UpdateShips();

            // this.satellite.TransmitMessages();
            satellite.TransmitMessagesFromPlayerToShips(playerManager, shipManager);
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


