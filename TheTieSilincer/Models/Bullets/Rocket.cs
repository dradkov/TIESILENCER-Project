using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTieSilincer.Models.Bullets
{
    public class Rocket : Bullet
    {
        private const char bulletType = '↑';

        public Rocket(int x, int y) : base(x, y)
        {

        }

        public override void UpdatePositionByX()
        {
            this.PreviousPosition = new Position(this.Position.X, this.Position.Y);
            this.Position.X--;
        }

        public override void UpdatePositionByY(List<Position> positions)
        {
            positions.Sort((x, y) => (x.X - this.Position.X) ^ 2 + (x.Y - this.Position.Y) ^ 2);

            Position nearestPoint = positions[0];

            if (nearestPoint != null)
            {
                if (nearestPoint.Y < this.Position.Y)
                {
                    this.Position.Y--;
                }

                if (nearestPoint.Y > this.Position.Y)
                {
                    this.Position.Y++;
                }
            }
        }

        public override void DrawBullet()
        {
            Console.SetCursorPosition(Position.Y, Position.X);
            Console.WriteLine(bulletType);
        }

        public override bool InBounds()
        {
            if (Position.X > 0)
            {
                return true;
            }

            return false;
        }
    }
}
