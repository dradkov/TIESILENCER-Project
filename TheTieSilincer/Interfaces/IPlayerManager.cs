namespace TheTieSilincer.Interfaces
{
    using TheTieSilincer.EventArguments;
    using TheTieSilincer.Models;

    public interface IPlayerManager : IGameObject
    {
        event PlayerPositionChangeEventHandler SendPlayerPosition;

        void CreatePlayer(IShip ship);

        void OnBulletCollision(object sender, ShipCollisionEventArgs args);

        void UpdateScore(object sender, NewDestroyShipEventArgs args);

        Player Player { get; }
    }
}