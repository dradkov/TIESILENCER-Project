using System;
using TheTieSilincer.Models;

namespace TheTieSilincer.Core
{
    using TheTieSilincer.Collisions;
    using TheTieSilincer.Models.Ships;

    public class Game
    {
        static private Satellite satellite;

        static private ShipManager shipManager;
        static private PlayerManager playerManager;

        static private BulletCollision bulletCollision;
        static private ShipCollision shipCollision;

        static public void Init()
        {

            shipManager = new ShipManager();
            playerManager = new PlayerManager();
            bulletCollision = new BulletCollision(shipManager, playerManager);
            shipCollision = new ShipCollision(shipManager);
            shipManager.GenerateShips();
            playerManager.CreatePlayer(shipManager.BuildPlayerShip("PlayerShip"));
            

            satellite = new Satellite(playerManager, shipManager);
            satellite.ReceiveDataByPlayer(playerManager);
            satellite.ReceiveDataFromShips(shipManager);

            satellite = new Satellite(playerManager, shipManager);
            shipManager = new ShipManager();
            playerManager = new PlayerManager();
            bulletCollision = new BulletCollision(shipManager, playerManager);
            shipCollision = new ShipCollision(shipManager);
            shipManager.GenerateShips();
            playerManager.CreatePlayer(shipManager.BuildPlayerShip("PlayerShip"));
            satellite.ReceiveDataByPlayer(playerManager);

        }



        static public void Clear()
        {
            playerManager.ClearPlayer();
            shipManager.ClearShips();
        }

        static public void CheckForCollisions()
        {
            bulletCollision.CheckForCollisions();
        }

        static public void Update()
        {
            playerManager.UpdatePlayer();
            shipManager.UpdateShips();


            // satellite.TransmitMessages();

            // satellite.TransmitMessages();

            satellite.TransmitMessagesFromPlayerToShips(playerManager, shipManager);
            satellite.TransmitMessagesFromShipsToPlayer(shipManager, playerManager);
        }

        static public void Draw()
        {
            playerManager.DrawPlayer();
            shipManager.DrawShips();
        }

        static public void InitialiseSettings()
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