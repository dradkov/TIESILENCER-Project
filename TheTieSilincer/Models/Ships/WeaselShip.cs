using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTieSilincer.Models.Bullets;

namespace TheTieSilincer.Models.Ships
{
    public class WeaselShip : EnemyShip
    {
        // \(|X|)/
        //    V
        private double movementTime = 0;
        private double bulletTime = 0;

        public WeaselShip()
        {
            
        }

        public override void ClearShip()
        {
            if (this.PreviousPosition != null)
            {
                Console.SetCursorPosition(this.PreviousPosition.Y, this.PreviousPosition.X);
                Console.WriteLine(@"       ");
                Console.SetCursorPosition(this.PreviousPosition.Y + 3, this.PreviousPosition.X + 1);
                Console.WriteLine(" ");
                this.Bullets.ForEach(v => v.ClearBullet());
            }

        }

        public override void DrawShip()
        {
           if(bulletTime % 2 == 0)
           {
               AddBullets();
               
           }
            
            Console.SetCursorPosition(this.Position.Y, this.Position.X);
            Console.WriteLine(@"\(|X|)/");
            Console.SetCursorPosition(this.Position.Y+3, this.Position.X+1);
            Console.WriteLine("V");
            this.Bullets.RemoveAll(v => !v.InBounds());
            this.Bullets.ForEach(v => v.DrawBullet());

            bulletTime += 0.25 ;
        }

        public override void UpdateShip()
        {
            this.Bullets.ForEach(v => v.UpdatePosition());
            if(movementTime % 2 == 0)
            {
                this.PreviousPosition = new Position(this.Position.X, this.Position.Y);
                this.Position.X++;
               
            }

            movementTime += 0.50;
        }

        public override bool InBounds(Position nextDirection)
        {
            if (Position.X == Console.WindowHeight - 2)
            {
                return false;
            }

            return true;
        }

        public override void AddBullets()
        {
            this.Bullets.Add(new WeaselBullet(this.Position.X + 2, this.Position.Y + 3));
        }
    }
}
