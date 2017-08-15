namespace TheTieSilincer.Interfaces
{
    using System.Collections.Generic;
    using TheTieSilincer.EventArguments;

    public interface IBulletManager : IGameObject
    {
        IList<IBullet> Bullets { get; }

        void ReceiveShipsPositions(object sender, EnemyShipsPositionChangeEventArgs args);

        void SubscribeForNewWeapons(object sender, NewWeaponsEventArgs args);

        void OnBulletCollision(object sender, BulletCollisionEventArgs args);

        void GeneratingBullets(object sender, BulletCoordsEventArgs args);
    }
}