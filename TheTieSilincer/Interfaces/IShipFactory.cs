using System.Collections.Generic;
using TheTieSilincer.Enums;
using TheTieSilincer.Models.Weapons;

namespace TheTieSilincer.Interfaces
{
    public interface IShipFactory
    {
        IShip CreateShip(ShipType shipType, IList<Weapon> weapons);
    }
}
