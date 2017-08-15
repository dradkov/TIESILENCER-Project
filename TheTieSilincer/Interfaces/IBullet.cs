namespace TheTieSilincer.Interfaces
{
    using TheTieSilincer.Enums;

    public interface IBullet : IGameObject, IPosition
    {
        BulletType BulletType { get; }

        bool InBounds();
    }
}