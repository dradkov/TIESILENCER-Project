using TheTieSilincer.Models;
using TheTieSilincer.Models.Bullets;

namespace TheTieSilincer.EventArguments
{
    public class BulletCollisionEventArgs
    {
        public BulletCollisionEventArgs(Bullet bullet)
        {
            this.Bullet = bullet;
        }

        public Bullet Bullet { get; private set; }
    }
}
