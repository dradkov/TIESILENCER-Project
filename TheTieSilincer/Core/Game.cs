namespace TheTieSilincer.Core
{
    using System;
    using TheTieSilincer.Collisions;
    using TheTieSilincer.Enums;
    using TheTieSilincer.Support;
    using TheTieSilincer.Core.Managers;
    using TheTieSilincer.Models;
    using TheTieSilincer.Interfaces;

    public class Game : IGame
    {
        private Satellite satellite;

        private IShipManager shipManager;
        private IPlayerManager playerManager;
        private IBulletManager bulletManager;

        private BulletCollision bulletCollision;
        private ShipCollision shipCollision;

        public Game()
        {
            this.satellite = new Satellite();          
            this.playerManager = new PlayerManager();
            this.bulletManager = new BulletManager();
            this.shipManager = new ShipManager();

            this.bulletCollision = new BulletCollision();
            this.shipCollision = new ShipCollision();

            this.satellite.StartTransmittingData(playerManager, shipManager, 
                bulletManager, bulletCollision, shipCollision);

            this.shipManager.GenerateShips();
            this.playerManager.CreatePlayer(shipManager.BuildShip(ShipType.PlayerShip));

        }

        public void Clear()
        {
            this.playerManager.Clear();
            this.shipManager.Clear();
            this.bulletManager.Clear();
        }

        public void CheckForCollisions()
        {
            this.bulletCollision.CheckForCollisions(this.bulletManager.Bullets, 
                this.shipManager.Ships, this.playerManager.Player.Ship);
            this.shipCollision.CheckForCollisions(this.shipManager.Ships, this.playerManager.Player.Ship);
        }

        public void Update()
        {
            this.playerManager.Update();
            this.shipManager.Update();
            this.bulletManager.Update();
        }

        public void Draw()
        {
            this.playerManager.Draw();
            this.shipManager.Draw();
            this.bulletManager.Draw();
        }

        public void InitialiseSettings()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.WindowHeight = Constants.WindowHeight;
            Console.WindowWidth = Constants.WindowWidth;
            Console.BufferHeight = Constants.WindowHeight;
            Console.BufferWidth = Constants.WindowWidth;

            this.playerManager.Draw();
        }
    }
}