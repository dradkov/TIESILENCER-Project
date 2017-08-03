using System;
using TheTieSilincer.Models.Bullets;

namespace TheTieSilincer.Models.Weapons
{
    public class MotherShipWeapon : Weapon
    {
        private int bulletCount = 4;

        public MotherShipWeapon()

        {
            this.ShootCooldown = 10;
        }

        public override void AddBullets(int x, int y)
        {
            //if (ShootCooldown == 10 || ShootCooldown == 20)
            //{
                this.Bullets.Add(new MSBullet(x, y));
          //  }

        }
    }
}
