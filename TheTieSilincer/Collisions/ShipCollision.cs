namespace TheTieSilincer.Collisions
{
    using System.Collections.Generic;
    using TheTieSilincer.Enums;
    using TheTieSilincer.EventArguments;
    using TheTieSilincer.Interfaces;
    using TheTieSilincer.Models;

    public class ShipCollision : Collision
    {
        public event ShipCollisionEventHandler shipCollidesWithAnotherShip;

        private void OnShipCollision(ShipCollisionEventArgs args)
        {
            shipCollidesWithAnotherShip?.Invoke(this, args);
        }

        private double intersectionPoint = 2;

        public void CheckForCollisions(IList<IShip> ships, IShip playerShip)
        {
            foreach (var ship in ships)
            {
                if (Intersect(ship.Position, playerShip.Position))
                {
                    OnShipCollision(new ShipCollisionEventArgs(ship, true));
                }
            }

            intersectionPoint = 7;

            for (int x = 0; x < ships.Count; x++)
            {
                var currentShip = ships[x];

                for (int y = 0; y < ships.Count; y++)
                {
                    var secondShip = ships[y];
                    if (x != y)
                    {
                        if (secondShip.ShipType == ShipType.MotherShip ||
                            currentShip.ShipType == ShipType.MotherShip)
                        {
                            intersectionPoint = 14;
                        }

                        if (secondShip.ShipType == ShipType.KamikazeShip &&
                            currentShip.ShipType == ShipType.KamikazeShip)
                        {
                            intersectionPoint = 3;
                        }

                        if (Intersect(currentShip.Position, secondShip.Position))
                        {
                            OnShipCollision(new ShipCollisionEventArgs(currentShip, false, secondShip));
                        }

                        intersectionPoint = 7;
                    }
                }
            }

            intersectionPoint = 2;
        }

        private bool Intersect(Position p1, Position p2)
        {
            distance = Distance(p1, p2);

            if (distance <= intersectionPoint)
            {
                return true;
            }

            return false;
        }
    }
}