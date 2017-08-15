namespace TheTieSilincer.EventArguments
{
    using System;
    using TheTieSilincer.Interfaces;

    public class BulletCollisionEventArgs : EventArgs
    {
        public BulletCollisionEventArgs(IBullet bullet)
        {
            this.Bullet = bullet;
        }

        public IBullet Bullet { get; private set; }
    }
}