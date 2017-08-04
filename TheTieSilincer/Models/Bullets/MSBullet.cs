using System;

namespace TheTieSilincer.Models.Bullets
{
    using System.Collections.Generic;
    using TheTieSilincer.Enums;

    public class MSBullet : Bullet
    {
        private const char bulletType = 'x';

        private const BulletType msBullet = BulletType.MSBullet;

        public MSBullet(Position position) : base(position, msBullet)
        {
        }

        public override void Draw()
        {
            Console.SetCursorPosition(Position.Y, Position.X);
            Console.WriteLine(bulletType);
        }

        public override bool InBounds(Position nextDirection = null)
        {
            if (Position.X == Console.WindowHeight - 2)
            {
                return false;
            }

            return true;
        }

        public override void UpdatePositionByX()
        {
            this.PreviousPosition = new Position(this.Position.X, this.Position.Y);
            this.Position.X++;
        }
        public override void UpdatePositionByY(List<Position> positions)
        {

        }

        public override void Update(Position nextDirection = null)
        {
            throw new NotImplementedException();
        }
    }
}
