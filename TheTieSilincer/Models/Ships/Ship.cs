using System.Collections.Generic;
using TheTieSilincer.Enums;
using TheTieSilincer.Interfaces;
using TheTieSilincer.Models.Weapons;

namespace TheTieSilincer.Models
{
    public abstract class Ship : IShip
    {
        public Ship(List<Weapon> weapons = null)
        {
            this.Weapons = weapons;
        }

        public ShipType ShipType { get; protected set; }

        public int Armor { get; set; }

        public int CollisionAOE { get; protected set; }

        public Position NextDirection { get;  set; }

        public Position Position { get; set; }

        public Position PreviousPosition { get; set; }

        public IList<Weapon> Weapons { get; private set; }

        public bool IsAlive()
        {
            if(this.Armor > 0)
            {
                return true;
            }

            return false;
        }

        public abstract bool InBounds();

        public abstract void Clear();

        public abstract void Draw();

        public abstract void Update();

        public abstract void ClearCurrentPosition();

    }
}
