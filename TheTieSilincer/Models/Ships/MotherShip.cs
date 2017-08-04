using System;
using System.Collections.Generic;
using TheTieSilincer.Models.Weapons;
using TheTieSilincer.Support;
using TheTieSilincer.Enums;
using TheTieSilincer.Core.Managers;

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

        private bool goLeft = false;
        private int interval = 17;

        public MotherShip(List<Weapon> weapons) : base(weapons)
        {
            this.ShipType = ShipType.MotherShip;
            this.Position = new Position(0, Console.WindowWidth / 3 + 2);
            this.CollisionAOE = 7;
            this.Armor = 25;

        }


        public override void Clear(bool destroyed = false)
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

            if (destroyed)
            {
                Console.SetCursorPosition(this.Position.Y, this.Position.X);
                Console.WriteLine("          ");
                Console.SetCursorPosition(this.Position.Y - 2, this.Position.X + 1);
                Console.WriteLine(@"              ");
                Console.SetCursorPosition(this.Position.Y + 1, this.Position.X + 2);
                Console.WriteLine(@"        ");
                Console.SetCursorPosition(this.Position.Y + 4, this.Position.X + 3);
                Console.WriteLine("  ");
            }

        }

        public override void Draw()
        {
            Console.SetCursorPosition(this.Position.Y, this.Position.X);
            Console.WriteLine("((||||||))");
            Console.SetCursorPosition(this.Position.Y - 2, this.Position.X + 1);
            Console.WriteLine(@"\|\xxxxxxxx/|/");
            Console.SetCursorPosition(this.Position.Y + 1, this.Position.X + 2);
            Console.WriteLine(@"\\VVVV//");
            Console.SetCursorPosition(this.Position.Y + 4, this.Position.X + 3);
            Console.WriteLine("WW");

            GenerateBullets();
        }

        public override void GenerateBullets()
        {
            if (interval == 17 || interval == 27 || interval == 34 || interval == 10 || interval == 3)
            {
                this.Weapons.ForEach(v => v.AddBullets(new Position(this.Position.X + 2, this.Position.Y - 1)));
                this.Weapons.ForEach(v => v.AddBullets(new Position(this.Position.X + 2, this.Position.Y + 10)));
                this.Weapons.ForEach(v => v.AddBullets(new Position(this.Position.X + 3, this.Position.Y + 2)));
                this.Weapons.ForEach(v => v.AddBullets(new Position(this.Position.X + 3, this.Position.Y + 7)));
                
            }
        }

        public override bool InBounds(Position nextDirection = null)
        {
            if (Position.Y < Constants.WindowWidth - 2 && Position.Y > 0)
            {
                return true;

            }

            return false;
        }

        public override void Update(Position nextDirection)
        {

            this.PreviousPosition = new Position(this.Position.X, this.Position.Y);
      
            
                if (this.Position.X < 2)
                {
                    this.Position.X++;
                }
                else
                {
                    if (goLeft)
                        this.Position.Y--;
                    else
                        this.Position.Y++;

                    if (this.interval == 0)
                        interval = 34;


                    this.interval--;
                }
            
            if (this.Position.Y <= 17 || this.Position.Y >= Constants.WindowWidth - 35)
            {
                goLeft = !goLeft;
            }
        }
    }
}
