namespace TheTieSilincer.Interfaces
{
    using TheTieSilincer.Enums;
    using TheTieSilincer.Models;

    public interface IBulletFactory
    {
        IBullet CreateBullet(BulletType bulletType, Position position);
    }
}