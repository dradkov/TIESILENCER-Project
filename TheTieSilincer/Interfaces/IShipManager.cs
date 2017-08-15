namespace TheTieSilincer.Interfaces
{
    using System.Collections.Generic;
    using TheTieSilincer.Enums;
    using TheTieSilincer.EventArguments;
    using TheTieSilincer.Models;

    public interface IShipManager : IGameObject
    {
        event EnemyShipsPositionChangeEventHandler SendShipsPositions;

        event NewWeaponsEventHandler SendNewWeapons;

        void OnShipCollision(object sender, ShipCollisionEventArgs args);

        void OnBulletCollision(object sender, ShipCollisionEventArgs args);

        void ReceivePlayerPosition(object sender, PlayerPositionChangeEventArgs args);

        IShip BuildShip(ShipType shipType);

        void GenerateShips();

        IList<IShip> Ships { get; }
    }
}