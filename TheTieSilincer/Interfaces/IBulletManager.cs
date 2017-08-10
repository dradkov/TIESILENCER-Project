using System.Collections;
using System.Collections.Generic;
using TheTieSilincer.EventArguments;

namespace TheTieSilincer.Interfaces
{
    public interface IBulletManager : IGameObject
    {
        IList<IBullet> Bullets { get; }

        void ReceiveShipsPositions(object sender, EnemyShipsPositionChangeEventArgs args);

        void SubscribeForNewWeapons(object sender, NewWeaponsEventArgs args);

        void OnBulletCollision(object sender, BulletCollisionEventArgs args);

        void GeneratingBullets(object sender, BulletCoordsEventArgs args);
    }
}
