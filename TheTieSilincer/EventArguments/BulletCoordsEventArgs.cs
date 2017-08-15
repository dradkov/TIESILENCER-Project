namespace TheTieSilincer.EventArguments
{
    using System;
    using TheTieSilincer.Enums;
    using TheTieSilincer.Models;

    public class BulletCoordsEventArgs : EventArgs
    {
        public BulletCoordsEventArgs(BulletType bulletType, Position position)
        {
            this.BulletType = bulletType;
            this.Position = position;
        }

        public BulletType BulletType { get; private set; }

        public Position Position { get; private set; }
    }
}