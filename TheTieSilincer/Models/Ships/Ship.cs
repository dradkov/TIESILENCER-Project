using System.Collections.Generic;
using TheTieSilincer.Enums;
using TheTieSilincer.Models.Weapons;

namespace TheTieSilincer.Models
{
    public abstract class Ship
    {
        public Ship() { }

        public Ship(List<Weapon> weapons = null)
        {
            this.Weapons = weapons;
        }

        public List<Weapon> Weapons { get; protected set; }

        public Position Position { get;  protected set; }

        public Position PreviousPosition { get; protected set; }

        public int Health { get; set; }

        public void SetPosition(Position pos)
        {
            this.Position = pos;
        }


        public void DrawBullets() => this.Weapons.ForEach(v=> v.DrawBullets());

        public void UpdateBullets() => this.Weapons.ForEach(v=> v.UpdateBullets());

        public void ClearBullets() => this.Weapons.ForEach(v=>v.ClearBullets());


        public abstract void UpdateShip(Position nextDirection = null);

        public abstract void DrawShip();

        public abstract void ClearShip();

        public abstract bool InBounds(Position nextDirection = null);
    }
}
