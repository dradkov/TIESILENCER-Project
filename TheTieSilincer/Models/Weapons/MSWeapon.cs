using System;
using TheTieSilincer.Models.Bullets;

namespace TheTieSilincer.Models.Weapons
{
    public class MSWeapon : Weapon
    {
        private int bulletCount = 4;

        public override void AddBullets(int x, int y)
        {
            this.Bullets.Add(new MSBullet(x, y));
            bulletCount--;
        }
    }
}
