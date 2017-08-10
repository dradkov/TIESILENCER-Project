using System;

namespace TheTieSilincer.Models.Bullets
{
    using System.Collections.Generic;
    using TheTieSilincer.Enums;
    using TheTieSilincer.Interfaces;

    public abstract class Bullet : IBullet
    {
        protected Bullet(Position position, BulletType bulletType)
        {
            this.Position = position;
            this.BulletType = bulletType;
        }
        
        public BulletType BulletType { get; private set; }
        public Position Position { get; set; }
        public Position PreviousPosition { get; set; }

        public void Clear()
        {
            if(this.PreviousPosition != null)
            {
                Console.SetCursorPosition(PreviousPosition.Y, PreviousPosition.X);
                Console.WriteLine(" ");
            }
        }

        public abstract void Draw();

        public abstract void Update();

        public abstract bool InBounds();

    }
}
