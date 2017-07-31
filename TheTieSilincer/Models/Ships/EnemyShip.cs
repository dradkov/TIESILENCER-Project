using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTieSilincer.Models.Ships
{
    public abstract class EnemyShip : Ship
    {
        protected EnemyShip()
        {       

        }

        public abstract void GenerateBullets();
               
    }
}
