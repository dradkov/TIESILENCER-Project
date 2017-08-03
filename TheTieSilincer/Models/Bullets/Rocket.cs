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
            Position nearestPoint = null;
            double dis = double.MaxValue;

            if(positions != null)
            {
                foreach (var pos in positions)
                {
                    double d = Math.Sqrt((this.Position.X - pos.X) * (this.Position.X - pos.X)
                        + (this.Position.Y - pos.Y) * (this.Position.Y - pos.Y));

                    if (d < dis)
                    {
                        dis = d;
                        nearestPoint = pos;
                    }
                }

                if (nearestPoint != null)
                {
                    if (nearestPoint.Y < Position.Y)
                    {
                        this.Position.Y--;
                    }
                    else
                    {
                        this.Position.Y++;
                    }

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
