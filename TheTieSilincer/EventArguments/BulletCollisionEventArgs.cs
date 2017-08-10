using System;
using TheTieSilincer.Interfaces;
using TheTieSilincer.Models;
using TheTieSilincer.Models.Bullets;

namespace TheTieSilincer.EventArguments
{
    public class BulletCollisionEventArgs : EventArgs
    {
        public BulletCollisionEventArgs(IBullet bullet)
        {
            this.Bullet = bullet;
        }

        public IBullet Bullet { get; private set; }
    }
}
