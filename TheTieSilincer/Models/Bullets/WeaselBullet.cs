using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTieSilincer.Models.Bullets
{
    public class WeaselBullet : Bullet
    {
        private const char bulletType = '*';

        public WeaselBullet(int x, int y) : base(x, y)
        {
        }

        public override void DrawBullet()
        {
            Console.SetCursorPosition(Position.Y, Position.X);
            Console.WriteLine(bulletType);
        }

        public override bool InBounds()
        {
            if (Position.X == Console.WindowHeight - 2)
            {
                return false;
            }

            return true;
        }

        public override void UpdatePosition()
        {
            this.PreviousPosition = new Position(this.Position.X, this.Position.Y);
            this.Position.X++;
        }
    }
}
