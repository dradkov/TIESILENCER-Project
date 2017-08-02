using System;

namespace TheTieSilincer.Models.Bullets
{
    using System.Collections.Generic;

    public abstract class Bullet
    {
        protected Bullet(int x, int y)
        {
            this.Position = new Position(x, y);
        }

        public Position Position { get; protected set; }

        public Position PreviousPosition { get; protected set; }

        public abstract void UpdatePositionByX();

        public abstract void UpdatePositionByY(List<Position> positions);

        public abstract void DrawBullet();

        public abstract bool InBounds();

        public virtual void ClearBullet()
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
