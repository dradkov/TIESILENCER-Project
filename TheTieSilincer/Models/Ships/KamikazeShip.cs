using System;
using System.Collections.Generic;
using TheTieSilincer.Models.Weapons;

namespace TheTieSilincer.Models.Ships
{
    public class KamikazeShip : EnemyShip
    {
        //   \^/
        //    V
        public KamikazeShip(List<Weapon> weapons) : base(weapons)
        {
            this.CollisionAOE = 3;
        }

        public KamikazeShip() : base() 
        {

        }

         

        private Position pos = null;
        
        private double movementTime = 0;

        public Position Pos
        {
            get
            {
                return pos;
            }

            set
            {
                pos = value;
            }
        }

        public override void ClearShip(bool destroyed = false)
        {
            if (this.PreviousPosition != null)
            {

                Console.SetCursorPosition(this.PreviousPosition.Y, this.PreviousPosition.X);
                Console.Write(@"    ");
                Console.SetCursorPosition(this.PreviousPosition.Y + 1, this.PreviousPosition.X + 1);
                Console.Write(@" ");
            }

            if(destroyed)
            {
                Console.SetCursorPosition(this.Position.Y, this.Position.X);
                Console.Write(@"    ");
                Console.SetCursorPosition(this.Position.Y + 1, this.Position.X + 1);
                Console.Write(@" ");
            }
        }

        public override void DrawShip()
        {
            Console.SetCursorPosition(this.Position.Y, this.Position.X);
            Console.WriteLine(@"\^/");
            Console.SetCursorPosition(this.Position.Y + 1, this.Position.X + 1);
            Console.WriteLine("V");
          
             
        }

        public override void UpdateShip(Position nextDirection)
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

            movementTime += 0.5;
        }

        public override bool InBounds(Position nextDirection)
        {
            if (Position.X == Console.WindowHeight - 2)
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
