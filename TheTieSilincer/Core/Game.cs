using System;
using TheTieSilincer.Models;

namespace TheTieSilincer.Core
{
    public class Game
    {
        private Player player;
        private int movement;
        private Position[] directions;
       


        public Game()
        {
            this.player = new Player();
            AddDirections();


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
        }

        public void CheckCollisions()
        {

        }

        public void Update()
        {
            this.player.Ship.UpdateBullets();
            ReadPlayerInput();
          
        }

        public void Draw()
        {
            this.player.Ship.DrawShip();
            this.player.Ship.DrawBullets();
        }

        public void InitialiseSettings()
        {
            Console.Clear(); 
            Console.CursorVisible = false;
            Console.SetWindowSize(100, 30);
            Console.SetBufferSize(100, 60);
            player.Ship.DrawShip();
        }

        public void ReadPlayerInput()
        {
           //if(Console.KeyAvailable)
           //{
                ConsoleKeyInfo userDirection = Console.ReadKey();


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
                    //this.player.Ship.Bullets.Add(new Bullet(this.player.Ship.Position.Y,
                      //  this.player.Ship.Position.X + 3));
                }

                if (userDirection.Key == ConsoleKey.RightArrow || userDirection.Key == ConsoleKey.DownArrow
                    || userDirection.Key == ConsoleKey.UpArrow || userDirection.Key == ConsoleKey.LeftArrow)
                {
                    Position nextDirection = directions[movement];
                    this.player.Ship.InBounds(nextDirection);
                }
           // }

           // }

        }
    }
}


