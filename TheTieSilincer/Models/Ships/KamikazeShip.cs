using System;
using System.Collections.Generic;
using TheTieSilincer.Models.Weapons;
using TheTieSilincer.Support;
using TheTieSilincer.Enums;

namespace TheTieSilincer.Models.Ships
{
    public class KamikazeShip : EnemyShip
    {
        //   \^/
        //    V

        public KamikazeShip(List<Weapon> weapons) : base(weapons)
        {
            this.ShipType = ShipType.KamikazeShip;
            this.CollisionAOE = 3;
            this.Armor = 3;
        }
        
        public Position Pos { get; set; }
        
        private double movementTime = 0;

        public override void Clear()
        {
            if (this.PreviousPosition != null)
            {

                Console.SetCursorPosition(this.PreviousPosition.Y, this.PreviousPosition.X);
                Console.Write(@"    ");
                Console.SetCursorPosition(this.PreviousPosition.Y + 1, this.PreviousPosition.X + 1);
                Console.Write(@" ");
            }
        }

        public override void ClearCurrentPosition()
        {
            Console.SetCursorPosition(this.Position.Y, this.Position.X);
            Console.Write(@"    ");
            Console.SetCursorPosition(this.Position.Y + 1, this.Position.X + 1);
            Console.Write(@" ");
        }

        public override void Draw()
        {
            Console.SetCursorPosition(this.Position.Y, this.Position.X);
            Console.WriteLine(@"\^/");
            Console.SetCursorPosition(this.Position.Y + 1, this.Position.X + 1);
            Console.WriteLine("V");
          
             
        }

        public override void Update()
        {
             

            if (movementTime % 2 == 0)
            {
                this.PreviousPosition = new Position(this.Position.X, this.Position.Y);

                this.Position.X++;

                if (this.Pos != null)
                {
                    if (this.Pos.Y < this.Position.Y)
                    {
                        this.Position.Y--;
                    }

                    if (this.Pos.Y > this.Position.Y)
                    {
                        this.Position.Y++;
                    }
                }




            }

            movementTime += 1;
        }

        public override bool InBounds()
        {
            if (Position.X == Constants.WindowHeight - 2)
            {
                return false;
            }

            return true;
        }

        public override void GenerateBullets()
        {
            
        }
    }
}
