using System;

namespace TheTieSilincer.Models.Bullets
{
    public abstract class Bullet
    {
        protected Bullet(int x, int y)
        {
            this.Position = new Position(x, y);
        }

        public Position Position { get; protected set; }

        public Position PreviousPosition { get; protected set; }

        public abstract void UpdatePosition();

        public abstract void DrawBullet();

        public abstract bool InBounds();

        public virtual void ClearBullet()
        {
            Console.SetCursorPosition(PreviousPosition.Y, PreviousPosition.X);
            Console.WriteLine(" ");
        }

    }
}
