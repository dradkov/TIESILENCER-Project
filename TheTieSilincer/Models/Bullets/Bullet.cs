using System;

namespace TheTieSilincer.Models.Bullets
{
    using System.Collections.Generic;
    using TheTieSilincer.Enums;

    public abstract class Bullet : GameObject
    {
        protected Bullet(Position position, BulletType bulletType)
        {
            this.Position = position;
            this.BulletType = bulletType;
        }
        
        public BulletType BulletType { get; private set; }

        public override void Clear(bool destroyed = false)
        {
            if(this.PreviousPosition != null)
            {
                Console.SetCursorPosition(PreviousPosition.Y, PreviousPosition.X);
                Console.WriteLine(" ");
            }
            else
            {
                Console.SetCursorPosition(Position.Y, Position.X);
                Console.WriteLine(" ");
            }

        }
    }
}
