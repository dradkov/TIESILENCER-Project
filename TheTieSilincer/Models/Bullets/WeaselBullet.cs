using System;

namespace TheTieSilincer.Models.Bullets
{
    using System.Collections.Generic;
    using TheTieSilincer.Enums;

    public class WeaselBullet : Bullet
    {
        private const char bulletType = '*';

        private const BulletType weaselBullet = BulletType.WeaselBullet;

        public WeaselBullet(Position position) : base(position, weaselBullet)
        {
        }

        public override void Draw()
        {
            Console.SetCursorPosition(Position.Y, Position.X);
            Console.WriteLine(bulletType);
        }

        public override bool InBounds()
        {
            if (Position.X == Console.WindowHeight - 2)
            {
                return false;
            }

            return true;
        }

        public override void Update()
        {
            this.PreviousPosition = new Position(this.Position.X, this.Position.Y);
            this.Position.X++;
        }

    }
}
