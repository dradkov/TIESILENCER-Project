﻿using System;
using TheTieSilincer.Core;
using TheTieSilincer.Models;

namespace TheTieSilincer.Collisions
{
    public abstract class Collision
    {
        protected ShipManager shipManager;

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

        public abstract bool Intersect();

        public abstract void CheckForCollisions();

    }
}