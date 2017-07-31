using System;
using TheTieSilincer.Models;
using TheTieSilincer.Models.Bullets;
using TheTieSilincer.Models.Ships;

namespace TheTieSilincer.Core
{
    public class Game
    {
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
            
        }

        private void AddDirections()
        {
            directions = new Position[]
           {
               new Position(0,1), //moving right
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

        }

        public void Update()
        {
            this.player.Ship.UpdateBullets();
            ReadPlayerInput();
            this.shipManager.UpdateShips();

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
                    this.player.Ship.Bullets.Add(new PlayerBullet(this.player.Ship.Position.X + 2
                        ,
                        this.player.Ship.Position.Y + 1));

                    this.player.Ship.Bullets.Add(new PlayerBullet(this.player.Ship.Position.X + 2
                        ,
                        this.player.Ship.Position.Y + 7));

                }

                if (userDirection.Key == ConsoleKey.RightArrow || userDirection.Key == ConsoleKey.DownArrow
                    || userDirection.Key == ConsoleKey.UpArrow || userDirection.Key == ConsoleKey.LeftArrow)
                {
                    Position nextDirection = directions[movement];
                    this.player.Ship.InBounds(nextDirection);
                }
            }

            // }

        }
    }
}


