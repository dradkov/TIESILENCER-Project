using TheTieSilincer.Models.Weapons;

namespace TheTieSilincer.Models
{
    public abstract class Ship
    {
        public Weapon Weapon { get; protected set; }

        public Position Position { get;  protected set; }

        public Position PreviousPosition { get; protected set; }

        public int Health { get; set; }

        public void SetPosition(Position pos)
        {
            this.Position = pos;
        }

        public abstract void UpdateShip();

        public abstract void DrawShip();

        public abstract void ClearShip();

        public abstract bool InBounds(Position nextDirection = null);
    }
}
