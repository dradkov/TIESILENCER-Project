using TheTieSilincer.EventArguments;
using TheTieSilincer.Models;

namespace TheTieSilincer.Interfaces
{
    public interface IPlayerManager : IGameObject
    {
        event PlayerPositionChangeEventHandler SendPlayerPosition;

        void CreatePlayer(IShip ship);

        void OnBulletCollision(object sender, ShipCollisionEventArgs args);

        Player Player { get; }
    }
}
