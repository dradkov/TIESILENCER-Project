using System;
using TheTieSilincer.Models.Weapons;

namespace TheTieSilincer.Models.Ships
{
    public class WeaselShip : EnemyShip
    {
        // \(|X|)/
        //    V
       // private double movementTime = 0;

        public WeaselShip()
        {
            this.Weapon = new WeaselWeapon();
        }

        public override void ClearShip()
        {
            if (this.PreviousPosition != null)
            {
                Console.SetCursorPosition(this.PreviousPosition.Y, this.PreviousPosition.X);
                Console.WriteLine(@"       ");
                Console.SetCursorPosition(this.PreviousPosition.Y + 3, this.PreviousPosition.X + 1);
                Console.WriteLine(" ");

                this.Weapon.ClearBullets();
            }
        }

        public override void DrawShip()
        {                               
            Console.SetCursorPosition(this.Position.Y, this.Position.X);
            Console.WriteLine(@"\(|X|)/");
            Console.SetCursorPosition(this.Position.Y+3, this.Position.X+1);
            Console.WriteLine("V");

            GenerateBullets();
            this.Weapon.DrawBullets();
        }

        public override void UpdateShip()
        {
            this.Weapon.UpdateBullets();

            if(this.MovementTime % 2 == 0)
            {
                this.PreviousPosition = new Position(this.Position.X, this.Position.Y);
                this.Position.X++;           
            }

            this.MovementTime += 0.50;
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
            this.Weapon.AddBullets(this.Position.X + 2, this.Position.Y + 3);
        }
    }
}
