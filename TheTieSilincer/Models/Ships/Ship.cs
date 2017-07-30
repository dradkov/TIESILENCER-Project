using System.Collections.Generic;

namespace TheTieSilincer.Models
{
    public abstract class Ship
    {
        protected Ship()
        {
            this.Position = new Position(0, 0);
            this.Bullets = new List<Bullet>();
        }

        public List<Bullet> Bullets { get; set; }

        public Position Position { get; set; }

        public Position PreviousPosition { get; set; }

        public abstract void UpdateShip();

        public abstract void DrawShip();

        public abstract void ClearShip();

        public abstract bool InBounds(Position nextDirection);
    }
}
