using System;
using System.Collections.Generic;
using System.Linq;
using TheTieSilincer.Models;

namespace TheTieSilincer.Core
{
    public class PlayerManager
    {
        public Player Player { get; private set; }
        private Position[] directions;
        private Position nextDirection;
        private ConsoleKeyInfo userDirection;
        private int movement;
        bool shooting;
        private int currentWeapon = 0;

        public PlayerManager()
        {
            this.AddDirections();
        }

        public event EventHandler SendData;
        public void StartSendingData()
        {
            this.SendData(this, EventArgs.Empty);

        }

        public void ListenEnemyShipsCoords(Satellite satellite)
        {
            satellite.SendData -= EnemyShipsSendedCoords;
            satellite.SendData += EnemyShipsSendedCoords;
        }

        public void EnemyShipsSendedCoords(object sender, EventArgs e)
        {
            List<Position> positions = ((Satellite)sender)
                .ShipManager
                .Ships
                .Select(x => x.Position).ToList();

              foreach (var weapon in this.Player.Ship.Weapons)
              {
                  weapon.Bullets.ForEach(x => x.UpdatePositionByY(positions));
              }
       
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

        public void CreatePlayer(PlayerShip ship)
        {
            this.Player = new Player(ship);
        }

        public void UpdatePlayer()
        {
            this.Player.Ship.UpdateBullets();
            this.ReadPlayerInput();
            this.Player.Ship.UpdateShip(nextDirection);
        }

        public void DrawPlayer()
        {
            this.Player.Ship.DrawShip();
            this.Player.Ship.DrawBullets();
        }

        public void ClearPlayer()
        {
            this.Player.Ship.ClearShip();
            this.Player.Ship.ClearBullets();
        }

        public void ReadPlayerInput()
        {          
            shooting = false;

            while (Console.KeyAvailable)
            {
                userDirection = Console.ReadKey(true);

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
                if (userDirection.Key == ConsoleKey.Spacebar)
                {
                    shooting = true;
                }
                if(userDirection.Key == ConsoleKey.V)
                {
                    currentWeapon = currentWeapon == 0 ? currentWeapon = 1 : currentWeapon = 0;
                }

                nextDirection = directions[movement];
            }

            if (shooting)
            {
                this.Player.Ship.Weapons[currentWeapon].AddBullets(this.Player.Ship.Position.X + 2,
                    this.Player.Ship.Position.Y + 1);
                this.Player.Ship.Weapons[currentWeapon].AddBullets(this.Player.Ship.Position.X + 2,
                    this.Player.Ship.Position.Y + 7);
            }
        }
    }
}
