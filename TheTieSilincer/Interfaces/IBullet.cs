using TheTieSilincer.Enums;

namespace TheTieSilincer.Interfaces
{
    public interface IBullet : IGameObject, IPosition
    {
        BulletType BulletType { get; }

        bool InBounds();
    }
}