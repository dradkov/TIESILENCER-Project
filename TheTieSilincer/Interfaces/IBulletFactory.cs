using TheTieSilincer.Enums;
using TheTieSilincer.Models;

namespace TheTieSilincer.Interfaces
{
    public interface IBulletFactory
    {
        IBullet CreateBullet(BulletType bulletType, Position position);
    }
}
