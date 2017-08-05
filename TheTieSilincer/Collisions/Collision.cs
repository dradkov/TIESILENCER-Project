using System;
using TheTieSilincer.Models;
using TheTieSilincer.Core.Managers;
using TheTieSilincer.Models.Bullets;
using System.Collections.Generic;

namespace TheTieSilincer.Collisions
{
    public abstract class Collision
    {
        protected ShipManager shipManager;

        protected double distance;

        protected Collision(ShipManager shipManager)
        {
            this.shipManager = shipManager;
        }

        public double Distance(Position position1 , Position position2)
        {
            double distance = Math.Sqrt((position1.X - position2.X) * (position1.X - position2.X) +
                (position1.Y - position2.Y) * (position1.Y - position2.Y));

            return distance;
        }

        public abstract void CheckForCollisions();

    }
}
