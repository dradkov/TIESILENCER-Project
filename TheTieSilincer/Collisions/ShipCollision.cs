﻿using System;
using TheTieSilincer.Core;

namespace TheTieSilincer.Collisions
{
    public class ShipCollision : Collision
    {
        public ShipCollision(ShipManager shipManager) : base(shipManager)
        {
        }

        public override void CheckForCollisions()
        {
            throw new NotImplementedException();
        }

        public override bool Intersect()
        {
            throw new NotImplementedException();
        }
    }
}
