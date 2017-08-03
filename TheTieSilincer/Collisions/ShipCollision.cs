using System;
using TheTieSilincer.Core;
using TheTieSilincer.Models;

namespace TheTieSilincer.Collisions
{
    public class ShipCollision : Collision
    {
        public ShipCollision(ShipManager shipManager) : base(shipManager)
        {
          
        }

        public override void CheckForCollisions()
        {
            for (int x = 0; x < this.shipManager.Ships.Count; x++)
            {
                var currentShip = shipManager.Ships[x];

                for (int y = 0; y < shipManager.Ships.Count; y++)
                {
                    if(x != y)
                    {
                        if (Intersect(currentShip.Position, shipManager.Ships[y].Position))
                        {

                        }
                        
                    }
                }
            }
        }

        private bool Intersect(Position p1 , Position p2)
        {
            distance = Distance(p1, p2);

            // TO DO
            return true;
        }
    }
}
