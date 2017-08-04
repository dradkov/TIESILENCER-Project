using System;

namespace TheTieSilincer.Models.Bullets
{
    using System.Collections.Generic;
    using TheTieSilincer.Enums;

    public class PlayerBullet : Bullet
    {
        private const char bulletType = '^';

        private const BulletType playerBullet = BulletType.PlayerBullet;

        public PlayerBullet(Position position) : base(position, playerBullet)
        {
        }

        public override void UpdatePositionByX()
        {
            this.PreviousPosition = new Position(this.Position.X, this.Position.Y);
            this.Position.X--;
        }

        public override void UpdatePositionByY(List<Position> positions)
        {

        }

        public override void Draw()
        {
            Console.SetCursorPosition(Position.Y, Position.X);
            Console.WriteLine(bulletType);
        }

        public override bool InBounds(Position nextDirection = null)
        {
            if(Position.X > 0)
            {
                return true;
            }

            return false;
        }

        public override void Update(Position nextDirection = null)
        {
            throw new NotImplementedException();
        }

    }
}
