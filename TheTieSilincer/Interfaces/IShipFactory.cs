namespace TheTieSilincer.Interfaces
{
    using System.Collections.Generic;
    using TheTieSilincer.Enums;
    using TheTieSilincer.Models.Weapons;

    public interface IShipFactory
    {
        IShip CreateShip(ShipType shipType, IList<Weapon> weapons);
    }
}