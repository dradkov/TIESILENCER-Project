using System;
using TheTieSilincer.Models;

namespace TheTieSilincer.Collisions
{
    public abstract class Collision
    {
        protected double distance;

        public double Distance(Position position1 , Position position2)
        {
            double distance = Math.Sqrt((position1.X - position2.X) * (position1.X - position2.X) +
                (position1.Y - position2.Y) * (position1.Y - position2.Y));

            return distance;
        }
    }
}
