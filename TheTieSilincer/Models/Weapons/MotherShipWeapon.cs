using System;
using TheTieSilincer.Models.Bullets;

namespace TheTieSilincer.Models.Weapons
{
    public class MotherShipWeapon : Weapon
    {

        public override void AddBullets(int x, int y)
        {
            this.Bullets.Add(new MSBullet(x, y));
        }
    }
}
