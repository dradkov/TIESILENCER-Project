using System;
using System.Collections;
using System.Collections.Generic;

namespace TheTieSilincer.Models.Ships
{
    public class MotherShip : EnemyShip
    {
        //         
        //       ((||||||))
        //     \|\xxxxxxxx/|/
        //        \\VVVV//
        //           WW
        //

        private Position[] positions;
        private bool goLeft = false;
        private int yInterval = 17;

        public MotherShip()
        {
            this.Position = new Position(0, Console.WindowWidth / 3 + 2);
            this.positions = new Position[2]
            {
                new Position(0, Console.WindowWidth / 3 + 2),
                new Position(0, Console.WindowWidth / 3 + 2)
            };

        }

        public override void ClearShip()
        {
            if (this.PreviousPosition != null)
            {
                Console.SetCursorPosition(this.PreviousPosition.Y, this.PreviousPosition.X);
                Console.WriteLine("          ");
                Console.SetCursorPosition(this.PreviousPosition.Y - 2, this.PreviousPosition.X + 1);
                Console.WriteLine(@"              ");
                Console.SetCursorPosition(this.PreviousPosition.Y + 1, this.PreviousPosition.X + 2);
                Console.WriteLine(@"        ");
                Console.SetCursorPosition(this.PreviousPosition.Y + 4, this.PreviousPosition.X + 3);
                Console.WriteLine("  ");
            }

        }

        public override void DrawShip()
        {
            Console.SetCursorPosition(this.Position.Y, this.Position.X);
            Console.WriteLine("((||||||))");
            Console.SetCursorPosition(this.Position.Y - 2, this.Position.X + 1);
            Console.WriteLine(@"\|\xxxxxxxx/|/");
            Console.SetCursorPosition(this.Position.Y + 1, this.Position.X + 2);
            Console.WriteLine(@"\\VVVV//");
            Console.SetCursorPosition(this.Position.Y + 4, this.Position.X + 3);
            Console.WriteLine("WW");

        }

        public override void GenerateBullets()
        {

        }

        public override bool InBounds(Position nextDirection = null)
        {
            return true;
        }

        public override void UpdateShip()
        {
            this.PreviousPosition = new Position(this.Position.X, this.Position.Y);
            if(MovementTime % 2 == 0)
            {
                if (this.Position.X < 2)
                {
                    this.Position.X++;
                }
                else
                {
                    if (!goLeft)
                    {
                        this.Position.Y--;
                        this.yInterval--;
                        if (this.yInterval == 0)
                        {
                            goLeft = !goLeft;
                            yInterval = 34;
                        }
                    }
                    else
                    {
                        this.Position.Y++;
                        this.yInterval--;
                        if (this.yInterval == 0)
                        {
                            goLeft = !goLeft;
                            yInterval = 34;
                        }
                    }
                }
            }

           // MovementTime += 0.50;

        }
    }
}
