using TheTieSilincer.Models;
using TheTieSilincer.Enums;
using TheTieSilincer.Core.Managers;
using TheTieSilincer.Models.Bullets;
using System.Collections.Generic;

namespace TheTieSilincer.Collisions
{
    public class ShipCollision : Collision
    {
        private int intersectionPoint = 7;

        public ShipCollision(ShipManager shipManager) : base(shipManager) { }

        public override void CheckForCollisions()
        {
            for (int x = 0; x < this.shipManager.Ships.Count; x++)
            {
                var currentShip = shipManager.Ships[x];

                for (int y = 0; y < shipManager.Ships.Count; y++)
                {
                    var secondShip = shipManager.Ships[y];
                    if (x != y)
                    {
                        if(secondShip.ShipType == ShipType.MotherShip ||
                            currentShip.ShipType == ShipType.MotherShip )
                        {
                            intersectionPoint = 14;
                        }

                        if (secondShip.ShipType == ShipType.KamikazeShip &&
                            currentShip.ShipType == ShipType.KamikazeShip )
                        {
                            intersectionPoint = 3;
                        }

                        if (Intersect(currentShip.Position, secondShip.Position))
                        {
                            currentShip.SetPreviousPosition(currentShip.Position);
                            secondShip.SetPreviousPosition(secondShip.Position);
                            currentShip.Clear();
                            secondShip.Clear();

                            if (currentShip.Position.Y <= shipManager.Ships[y].Position.Y)
                            {                               
                                currentShip.Position.Y--;
                             
                            }
                            else
                            {
                                currentShip.Position.Y++;
                            }

                        }

                        intersectionPoint = 7;
                        
                    }
                }
            }
        }

        private bool Intersect(Position p1 , Position p2)
        {
            distance = Distance(p1, p2);

            if(distance < intersectionPoint)
            {
                return true;
            }

            return false;
        }
    }
}
