using System;
using System.Collections.Generic;
using TheTieSilincer.Models.Bullets;

namespace TheTieSilincer.Models
{
    public abstract class Ship
    {
        protected Ship()
        {
            this.Position = new Position(Console.WindowHeight - 8, Console.WindowWidth / 3 + 5);
            this.Bullets = new List<Bullet>();
        }

        public List<Bullet> Bullets { get; set; }

        public Position Position { get; set; }

        public Position PreviousPosition { get; set; }

        public abstract void UpdateShip();

        public abstract void DrawShip();

        public abstract void ClearShip();

        public abstract bool InBounds(Position nextDirection = null);
    }
}
