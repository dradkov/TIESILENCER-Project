using System.Collections.Generic;
using TheTieSilincer.Models.Weapons;

namespace TheTieSilincer.Models.Ships
{
    public abstract class EnemyShip : Ship
    {

        protected EnemyShip(List<Weapon> weapons) : base(weapons)
        {       

        }

        public double MovementSpeed { get; protected set;  }

        public abstract void GenerateBullets();   


               
    }
}
