using TheTieSilincer.Models;

namespace TheTieSilincer.EventArguments
{
    public class ShipCollisionEventArgs
    {
        public ShipCollisionEventArgs(Ship ship, bool shipCollidesWithPlayerShip, Ship ship2 = null)
        {
            this.Ship = ship;
            this.ShipCollidesWithPlayerShip = shipCollidesWithPlayerShip;
            this.Ship2 = ship2;
        }

        public Ship Ship { get; private set; }

        public Ship Ship2 { get; private set; }

        public bool ShipCollidesWithPlayerShip { get; private set; }
    }
}
