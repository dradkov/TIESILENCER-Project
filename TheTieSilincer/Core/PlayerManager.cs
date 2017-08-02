using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTieSilincer.Models;

namespace TheTieSilincer.Core
{
    public class PlayerManager
    {
        public Player Player { get; private set; }
        private int movement;
        private Position[] directions;
        private Position nextDirection;

        public PlayerManager()
        {
            this.AddDirections();
        }

        //public void ListenEnemyShipsCoords(Satellite satellite)
        //{
        //    satellite.SendData2 -= EnemyShipsSendedCoords;
        //    satellite.SendData2 += EnemyShipsSendedCoords;
        //}

        //public void EnemyShipsSendedCoords(object sender, EventArgs e)
        //{
        //    Position position = ((Satellite)sender).Position;

        //    foreach (var ship in this.Ships)
        //    {
        //        if (ship.GetType() == typeof(KamikazeShip))
        //        {
        //            (ship as KamikazeShip).Pos = position;
        //        }
        //    }
        //}

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
            ConsoleKeyInfo userDirection;

            if (Console.KeyAvailable)
            {
                 userDirection = Console.ReadKey();

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
                     this.Player.Ship.Weapons.ForEach(v=>v.AddBullets(this.Player.Ship.Position.X + 2,
                         this.Player.Ship.Position.Y + 1));
                     this.Player.Ship.Weapons.ForEach(v=>v.AddBullets(this.Player.Ship.Position.X + 2,
                         this.Player.Ship.Position.Y + 7));

                    nextDirection = null;

                    return;
                }

               // if (userDirection.Key == ConsoleKey.RightArrow || userDirection.Key == ConsoleKey.DownArrow
               //     || userDirection.Key == ConsoleKey.UpArrow || userDirection.Key == ConsoleKey.LeftArrow)
               // {
                   nextDirection = directions[movement];
                 // this.Player.Ship.InBounds(nextDirection);
               // }
            }


            
        }




    }
}
