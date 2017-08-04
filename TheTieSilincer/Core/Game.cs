using System;

namespace TheTieSilincer.Core
{
    using TheTieSilincer.Collisions;
    using TheTieSilincer.Enums;
    using TheTieSilincer.Support;

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
            this.playerManager.CreatePlayer(shipManager.BuildShip(ShipType.PlayerShip));

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
            shipCollision.CheckForCollisions();
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
            Console.WindowHeight = Constants.WindowHeight;
            Console.WindowWidth = Constants.WindowWidth;
            Console.BufferHeight = Constants.WindowHeight;
            Console.BufferWidth = Constants.WindowWidth;

            playerManager.DrawPlayer();
        }
    }
}