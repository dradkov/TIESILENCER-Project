using TheTieSilincer.Interfaces;
using TheTieSilincer.Models;

namespace TheTieSilincer.EventArguments
{
    public class ShipCollisionEventArgs
    {
        public ShipCollisionEventArgs(IShip ship, bool shipCollidesWithPlayerShip, IShip ship2 = null)
        {
            this.Ship = ship;
            this.ShipCollidesWithPlayerShip = shipCollidesWithPlayerShip;
            this.Ship2 = ship2;
        }

        public IShip Ship { get; private set; }

        public IShip Ship2 { get; private set; }

        public bool ShipCollidesWithPlayerShip { get; private set; }
    }
}
