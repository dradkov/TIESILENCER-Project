using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTieSilincer.Models.Bullets;

namespace TheTieSilincer.Models.Weapons
{
    public class PlayerRocketLauncher : Weapon
    {
        public override void AddBullets(int x, int y)
        {
            this.Bullets.Add(new Rocket(x, y));
        }
    }
}
