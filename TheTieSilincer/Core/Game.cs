using System;
using TheTieSilincer.Models;

namespace TheTieSilincer.Core
{
    using TheTieSilincer.Collisions;
    using TheTieSilincer.Enums;
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
            this.shipManager = new ShipManager();
            this.playerManager = new PlayerManager();
            this.bulletCollision = new BulletCollision(shipManager, playerManager);
            this.shipCollision = new ShipCollision(shipManager);
            this.shipManager.GenerateShips();
            this.playerManager.CreatePlayer(shipManager.BuildPlayerShip(ShipType.PlayerShip));

            this.satellite = new Satellite(playerManager, shipManager);
            this.satellite.ReceiveDataByPlayer();
            this.satellite.ReceiveDataFromShips();
        }

        public void Clear()
        {
            playerManager.ClearPlayer();
            shipManager.ClearShips();
        }

        public void CheckForCollisions()
        {
            bulletCollision.CheckForCollisions();
        }

        public void Update()
        {
            playerManager.UpdatePlayer();
            shipManager.UpdateShips();

            satellite.TransmitMessages();

        }

        public void Draw()
        {
            playerManager.DrawPlayer();
            shipManager.DrawShips();
        }

        public void InitialiseSettings()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.WindowHeight = 30;
            Console.WindowWidth = 100;
            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;

            playerManager.DrawPlayer();
        }
    }
}