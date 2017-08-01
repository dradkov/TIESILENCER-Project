using System;
using TheTieSilincer.Models;

namespace TheTieSilincer.Core
{
    using TheTieSilincer.Models.Ships;

    public class Game
    {
        private Satellite satellite;
        private ShipManager shipManager;
        private Player player;
        private int movement;
        private Position[] directions;

        public Game()
        {
            this.shipManager = new ShipManager();
            this.player = new Player();
            AddDirections();
            this.shipManager.GenerateShips();

            this.satellite = new Satellite();
            this.satellite.ReceiveDataByPlayer(player.Ship);
        }

        private void AddDirections()
        {
            directions = new Position[]
           {
               new Position(0,1), // moving right
                new Position( 0,-1), // moving left
                new Position( 1,0), // moving down
                new Position(-1,0), // moving up
           
           };
        }

        public void Clear()
        {
            this.player.Ship.ClearShip();
            this.player.Ship.ClearBullets();
            this.shipManager.ClearShips();
        }

        public void CheckCollisions()
        {
            for (int i = 0; i < this.shipManager.Ships.Count; i++)
            {
                var ship = this.shipManager.Ships[i];

                for (int j = 0; j < this.player.Ship.Weapon.Bullets.Count; j++)
                {
                    var bullet = this.player.Ship.Weapon.Bullets[j];
                    if (bullet.Position.X - 3 < ship.Position.X && bullet.Position.X + 2 > ship.Position.X && bullet.Position.Y + 4 > ship.Position.Y && bullet.Position.Y - 4 < ship.Position.Y)
                    {
                        player.Ship.Weapon.Bullets.Remove(bullet);
                        ship.ClearShip();
                        shipManager.Ships.Remove(ship);


                        break;
                    }
                }
            }
        }

        public void Update()
        {
            this.player.Ship.UpdateBullets();
            ReadPlayerInput();
            this.shipManager.UpdateShips();

            TransmitMessages();

        }

        private void TransmitMessages()
        {
            if (shipManager.Ships.Count > 0)
            {
                foreach (var ship in this.shipManager.Ships)
                {
                    if (ship.GetType() == typeof(KamikazeShip))
                        (ship as KamikazeShip).ListenPlayerShipCoords(this.satellite);
                }
                this.player.Ship.StartSendingData();
                this.satellite.StartSendingData();

            }
        }

        public void Draw()
        {
            this.player.Ship.DrawShip();
            this.player.Ship.DrawBullets();
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

            player.Ship.DrawShip();
        }

        public void ReadPlayerInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userDirection = Console.ReadKey();

                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                if (userDirection.Key == ConsoleKey.RightArrow)
                {
                    movement = 0;
                }
                else if (userDirection.Key == ConsoleKey.LeftArrow)
                {
                    movement = 1;
                }
                else if (userDirection.Key == ConsoleKey.DownArrow)
                {
                    movement = 2;
                }
                else if (userDirection.Key == ConsoleKey.UpArrow)
                {
                    movement = 3;
                }
                else if (userDirection.Key == ConsoleKey.Spacebar)
                {
                    this.player.Ship.Weapon.AddBullets(this.player.Ship.Position.X + 2,                      
                        this.player.Ship.Position.Y + 1);
                    this.player.Ship.Weapon.AddBullets(this.player.Ship.Position.X + 2,
                        this.player.Ship.Position.Y + 7);
                }

                if (userDirection.Key == ConsoleKey.RightArrow || userDirection.Key == ConsoleKey.DownArrow
                    || userDirection.Key == ConsoleKey.UpArrow || userDirection.Key == ConsoleKey.LeftArrow)
                {
                    Position nextDirection = directions[movement];
                    this.player.Ship.InBounds(nextDirection);
                }
            }

        }
    }
}


