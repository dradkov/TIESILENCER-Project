namespace TheTieSilincer.Interfaces
{
    using System.Collections.Generic;
    using TheTieSilincer.Enums;
    using TheTieSilincer.Models;
    using TheTieSilincer.Models.Weapons;

    public interface IShip : IGameObject, IPosition, IDestroyable
    {
        Position NextDirection { get; set; }

        ShipType ShipType { get; }

        IList<Weapon> Weapons { get; }

        int CollisionAOE { get; }

        bool IsAlive();

        bool InBounds();

        void ClearCurrentPosition();
    }
}