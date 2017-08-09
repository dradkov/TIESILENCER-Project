using System.Collections.Generic;
using TheTieSilincer.Enums;
using TheTieSilincer.Models;
using TheTieSilincer.Models.Weapons;

namespace TheTieSilincer.Interfaces
{
    public interface IShip : IGameObject, IPosition
    {
        Position NextDirection { get; set; }

        ShipType ShipType { get; }

        IList<Weapon> Weapons { get; }

        int Armor { get; set; }

        int CollisionAOE { get; }

        bool IsAlive();

        bool InBounds();

        void ClearCurrentPosition();
    }
}
