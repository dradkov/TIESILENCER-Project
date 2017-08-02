using System.Collections.Generic;
using TheTieSilincer.Models.Weapons;

namespace TheTieSilincer.Models.Ships
{
    public abstract class EnemyShip : Ship
    {
        public EnemyShip()
        {
        }

        protected EnemyShip(List<Weapon> weapons) : base(weapons)
        {       

        }

        public double MovementTime { get; protected set;  }

        public abstract void GenerateBullets();   


               
    }
}
