namespace TheTieSilincer.Interfaces
{
    using TheTieSilincer.EventArguments;
    using TheTieSilincer.Models;

    public interface IPlayerManager : IGameObject
    {
        event PlayerPositionChangeEventHandler SendPlayerPosition;

        void CreatePlayer(IShip ship);

        void OnBulletCollision(object sender, ShipCollisionEventArgs args);

        Player Player { get; }
    }
}